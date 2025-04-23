using SpectreMod.Content.Items.CharmsFragments;
using SpectreMod.Core.ModPlayer;
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
    public class CharmProgress_Base : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Green;
            Item.defense = 10;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return GlobalCharmLogic.ValidEquip(equippedItem, incomingItem, player);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.1f; //+10% damage
            player.GetModPlayer<CharmProgressPlayer>().intensity = 10; //10% boost to accel speed
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TwinsFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DestroyerFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SkeletronPrimeFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<QueenSlimeFragment>(), 1);
            recipe.AddIngredient(ModContent.ItemType<PlanteraFragment>(), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }

    public class CharmProgressPlayer : ModPlayer
    {
        public int intensity;
        public override void PostUpdateRunSpeeds()
        {
            base.PostUpdateRunSpeeds();
            Player.accRunSpeed *= 1 + (intensity / 100);
        }
        public override void ResetEffects()
        {
            base.ResetEffects();
            intensity = 0;
        }
    }
}
