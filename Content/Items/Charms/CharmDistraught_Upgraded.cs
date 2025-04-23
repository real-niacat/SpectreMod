using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpectreMod.Content.Items.Charms;
using SpectreMod.Content.Materials;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using SpectreMod.Core.SpecialGroups;

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
            if (equippedItem.ModItem is CharmDistraught_Base && equippedItem != incomingItem)
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
            else if (equippedItem.ModItem is CharmProgress_Upgraded && equippedItem != incomingItem)
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
