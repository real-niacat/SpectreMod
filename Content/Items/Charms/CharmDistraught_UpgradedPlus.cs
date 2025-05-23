﻿using SpectreMod.Content.Materials;
using SpectreMod.Core.usermodifier;
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
    public class CharmDistraught_UpgradedPlus : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";

        public override void SetDefaults()
        {
            //this is copied code from myself
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return GlobalCharmLogic.ValidEquip(equippedItem, incomingItem, player);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<CharmDistraughtPlayer>().intensity = 3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<CharmDistraught_Upgraded>();
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
