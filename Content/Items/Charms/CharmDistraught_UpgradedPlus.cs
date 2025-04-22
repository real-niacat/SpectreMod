using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using SpectreMod.Content.Materials;

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
        
        public virtual bool CanAccessoryBeEquippedWith(Item equippedItem, Item itemToEquip, Player player, AccessorySlotType context)
        {
            if (equippedItem.ModItem is CharmDistraught_Upgraded && equippedItem != itemToEquip)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            return true; // Allows equipping other charms or items
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
