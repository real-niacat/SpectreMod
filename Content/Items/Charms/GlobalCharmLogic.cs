using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace SpectreMod.Content.Items.Charms
{
    public class GlobalCharmLogic
    {
        public static bool ItemIsCharm(int itemID)
        {
            if (
                itemID == ModContent.ItemType<CharmDistraught_Base>() ||
                itemID == ModContent.ItemType<CharmDistraught_Upgraded>() ||
                itemID == ModContent.ItemType<CharmDistraught_UpgradedPlus>() ||
                itemID == ModContent.ItemType<CharmProgress_Base>() ||
                itemID == ModContent.ItemType<CharmProgress_Upgraded>() ||
                itemID == ModContent.ItemType<CharmLunacy>()
                )
            {
                return true;
            }
            return false;
        }

        public static bool ValidEquip(Item equippedItem, Item incomingItem, Player player)
        {
            //return true;

            //if (equippedItem == null) { return true; }
            if (incomingItem == null) { return true; }
            int i = incomingItem.type;
            if (ItemIsCharm(i))
            {
                return false;
            }

            return true; // Allows equipping other charms or items
        }
    }
}
