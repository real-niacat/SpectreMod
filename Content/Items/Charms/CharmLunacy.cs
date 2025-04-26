using Microsoft.Xna.Framework;
using Mono.CompilerServices.SymbolWriter;
using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.usermodifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmLunacy : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return GlobalCharmLogic.ValidEquip(equippedItem, incomingItem, player);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CharmLunacyPlayer>().lunatic = true;
            player.GetModPlayer<CharmLunacyPlayer>().lunacy_charm = Item;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GolemFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DukeFishronFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EmpressOfLightFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<LunaticCultistFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MoonLordFragment>(), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }

    public class CharmLunacyPlayer : ModPlayer
    {
        public bool lunatic;
        public Item lunacy_charm;

        public override void ResetEffects()
        {
            lunatic = false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (lunatic && damageDone > 10)
            {
                Vector2 calculatedVelocity = target.Center - Player.Center;
                calculatedVelocity.Normalize();
                calculatedVelocity *= 15;
                Projectile p = Projectile.NewProjectileDirect(Player.GetSource_Accessory(lunacy_charm), Player.Center, calculatedVelocity, ProjectileID.VampireKnife, damageDone / 2, 3);
                p.extraUpdates = 1;


                if ((Main.rand.Next(100)+1) < 20)
                {
                    int off = 30;
                    int randomOffset = Main.rand.Next((off*2)+1) - (off / 2);
                    Vector2 skyPosition = Player.Center + (new Vector2(randomOffset, -60) * 16); //multiplied by 16 as vectors are stored in units which are 1/16 of tiles
                    Vector2 vel = target.Center - skyPosition;
                    vel.Normalize();
                    vel *= 7;
                    Projectile meteor = Projectile.NewProjectileDirect(Player.GetSource_Accessory(lunacy_charm), skyPosition, vel, ProjectileID.Meteor1, damageDone * 2, 3);
                }
            }
        }
    }
}
