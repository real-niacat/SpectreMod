using SpectreMod.Content.Items.Charms;
using SpectreMod.Core.ModExtend;
using Terraria;
using Terraria.ModLoader;

namespace SpectreMod.Common.UIExtensions
{
    public class CharmSlot : ModAccessorySlot
    {
        public override bool IsVisibleWhenNotEnabled() => true;
        public override bool IsEnabled()
        {
            return Player.extraAccessorySlots > 0 && Player.GetModPlayer<SpectrePlayer>().CharmSlot && Player.CurrentLoadoutIndex == SpectrePlayer.CharmLoadout;
        }
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is CharmDistraught_Base)
            {
                return true; // Allow equipping charms in the functional slot
            }
            else if (context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is CharmDistraught_Upgraded)
            {
                return true; // Allow equipping charms in the vanity slot
            }
            else if (context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is CharmDistraught_UpgradedPlus)
            {
                return true; // Allow equipping charms in the dye slot
            }
            else if (context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is CharmProgress_Base)
            {
                return true; // Allow equipping charms in the functional slot
            }
            else if (context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is CharmProgress_Upgraded)
            {
                return true; // Allow equipping charms in the vanity slot
            }
            else if (context == AccessorySlotType.FunctionalSlot && checkItem.ModItem is CharmLunacy)
            {
                return true; // Allow equipping charms in the dye slot
            }
            return false; // Prevent equipping other items in the charm slots
        }

        public override string FunctionalTexture => "SpectreMod/Common/Placeholders/PlaceHolder";
        public override string FunctionalBackgroundTexture => "SpectreMod/Common/Placeholders/PlaceHolder";
        public override string VanityBackgroundTexture => "SpectreMod/Common/Placeholders/PlaceHolder";

        public override void OnMouseHover(AccessorySlotType context)
        {
            base.OnMouseHover(context);
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Charm Slot";
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = "Charm Slot Vanity";
                    break;
                case AccessorySlotType.DyeSlot:
                    Main.hoverItemName = "Charm Slot Dye";
                    break;
            }
        }
    }
    public class SpectrePlayer : ModPlayer
    {
        public const int CharmLoadout = 0;
        public bool CharmSlot { get; set; } = true;

        public override void ResetEffects()
        {
            CharmSlot = true;
        }
    }
}