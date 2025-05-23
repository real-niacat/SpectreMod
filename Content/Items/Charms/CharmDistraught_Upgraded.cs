﻿using SpectreMod.Content.Items.Charms;
using SpectreMod.Content.Items.Materials;
using SpectreMod.Core.usermodifier;
using SpectreMod.Core.SpecialGroups;
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
    public class CharmDistraught_Upgraded : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";

        public override void SetDefaults()
        {
            //this is copied code from myself
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            return GlobalCharmLogic.ValidEquip(equippedItem, incomingItem, player);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 0.93f;
            player.GetModPlayer<CharmDistraughtPlayer>().intensity = 2;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<CharmDistraught_Base>();
            recipe.AddIngredient<PlanterasSeed>();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
