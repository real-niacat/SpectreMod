using MonoMod.Core.Platforms;
using SpectreMod.Content.Buffs;
using SpectreMod.Content.Items.CharmsFragments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmDistraught_Base : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        
        public virtual bool CanAccessoryBeEquippedWith(Item equippedItem, Item itemToEquip, Player player, AccessorySlotType context)
        {
            if (equippedItem.ModItem is CharmDistraught_Base && equippedItem != itemToEquip)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            return true; // Allows equipping other charms or items
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 0.9f; //i know it's a bit unforgiving but, it says -10% damage, and god damn it im going to make it take away 10% of your damage.
            player.GetModPlayer<CharmDistraughtPlayer>().intensity = 1;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SlimeFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EoCFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EvilFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<QueenBeeFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SkeletronFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DeerClopsFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<WoFFragment>(), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }

    public class CharmDistraughtPlayer : ModPlayer
    {
        public int intensity;
        public static int[] pool_base = { BuffID.Poisoned, BuffID.Bleeding, BuffID.OnFire, BuffID.Frostburn };
        public static int[] pool_upgr = { BuffID.Ichor, BuffID.Electrified };
        public static int[] pool_max = { BuffID.CursedInferno, ModContent.BuffType<MagmatingDebuff>() };
        //sorry for using 3 different variables

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            base.ModifyHitNPC(target, ref modifiers);

            if (intensity > 0)
            {
                int chance = 40 + (intensity * 20); //really dumb way to do it, but it works ehe
                int[] pool = pool_base;
                if (intensity > 1) { pool = [.. pool, .. pool_upgr]; }
                if (intensity > 2) { pool = [.. pool, .. pool_max]; }

                int rnd = Main.rand.Next(100) + 1; //.Next(int) is inclusive to 0 and exclusive to n, adding 1 is useful for what we need.
                if (rnd <= chance)
                {
                    target.AddBuff(pool[Main.rand.Next(pool.Length)], 15*60);
                }
            }
        }
        public override void ResetEffects()
        {
            base.ResetEffects();
            intensity = 0; //reset the intensity to 0, so it doesn't stack with other charms
        }
    }
}
