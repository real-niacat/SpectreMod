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
    public class EoCFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public EoCFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.EoCCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedBoss1;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class EvilFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public EvilFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.EoWCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedBoss2;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class SkeletronFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public SkeletronFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.SkeletronCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedBoss3;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class QueenBeeFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public QueenBeeFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.QueenBeeCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedQueenBee;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class DeerClopsFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DeerClopsFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.DeerClopsCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedDeerclops;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class WoFFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public WoFFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.WoFCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! Main.hardMode;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
}