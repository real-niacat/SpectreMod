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
    public class CharmProgress_Upgraded : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = ItemRarityID.Purple; //upgraded rarity
            Item.defense = 15;
        }
        
        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (equippedItem.ModItem is CharmDistraught_Base && equippedItem != incomingItem)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            else if (equippedItem.ModItem is CharmDistraught_Upgraded && equippedItem != incomingItem)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            else if (equippedItem.ModItem is CharmDistraught_UpgradedPlus && equippedItem != incomingItem)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            else if (equippedItem.ModItem is CharmProgress_Base && equippedItem != incomingItem)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            else if (equippedItem.ModItem is CharmLunacy && equippedItem != incomingItem)
            {
                return false; // Prevents equipping multiple charms of the same type
            }
            return true; // Allows equipping other charms or items
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) += 0.2f; //+10% damage
            player.GetModPlayer<CharmProgressPlayer>().intensity = 20; //10% boost to accel speed
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient<CharmProgress_Base>();
            recipe.AddIngredient(ItemID.LunarBar, 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
