using SpectreMod.Content.Items.Charms;
using SpectreMod.Core.ModPlayer;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace SpectreMod.Common.Players
{
    public class CharmSlot : ModAccessorySlot
    {
        public override bool IsVisibleWhenNotEnabled() => true;
        public override bool IsEnabled()
        {
            return Player.extraAccessorySlots >= 0 && Player.GetModPlayer<SpectrePlayer>().CharmSlot && Player.CurrentLoadoutIndex >= SpectrePlayer.CharmLoadout;
        }
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ModContent.ItemType<CharmDistraught_Base>() ||
                checkItem.type == ModContent.ItemType<CharmDistraught_Upgraded>() ||
                checkItem.type == ModContent.ItemType<CharmDistraught_UpgradedPlus>() ||
                checkItem.type == ModContent.ItemType<CharmProgress_Base>() ||
                checkItem.type == ModContent.ItemType<CharmProgress_Upgraded>() ||
                checkItem.type == ModContent.ItemType<CharmLunacy>())
            {
                return true;
            }
            return false;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo)
        {
            if (item.type == ModContent.ItemType<CharmDistraught_Base>() ||
                item.type == ModContent.ItemType<CharmDistraught_Upgraded>() ||
                item.type == ModContent.ItemType<CharmDistraught_UpgradedPlus>() ||
                item.type == ModContent.ItemType<CharmProgress_Base>() ||
                item.type == ModContent.ItemType<CharmProgress_Upgraded>() ||
                item.type == ModContent.ItemType<CharmLunacy>())
            {
                return true;
            }
            return false;
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