using SpectreMod.Common.Players;
using SpectreMod.Content.CharmsFragments;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace SpectreMod.Core.DropConditions
{
    // This is a drop condition that checks if the player has the Slime Charm equipped.
    public class SlimeFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public SlimeFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.SlimeCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedSlimeKing;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
}