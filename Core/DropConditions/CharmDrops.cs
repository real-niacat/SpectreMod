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
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.EvilCharm");
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
    public class DestroyerFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DestroyerFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.DestroyerCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedMechBoss1;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class TwinsFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public TwinsFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.TwinsCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedMechBoss2;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class SkeletronPrimeFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public SkeletronPrimeFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.SkeletronPrimeCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedMechBoss3;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class PlanteraFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public PlanteraFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.PlanteraCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedPlantBoss;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class QueenSlimeFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public QueenSlimeFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.QueenSlimeCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedQueenSlime;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class GolemFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public GolemFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.GolemCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedGolemBoss;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class EmpressFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public EmpressFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.EmpressCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedEmpressOfLight;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class DukeFishronFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public DukeFishronFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.DukeFishronCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedFishron;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class CultistFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public CultistFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.CultistCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedAncientCultist;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
    public class MoonLordFragmentDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public MoonLordFragmentDropCondition() {
            Description ??= Language.GetOrRegister("Mods.SpectreMod.DropConditions.MoonLordCharm");
        }

        public bool CanDrop(DropAttemptInfo info) {
            return Main.expertMode &! NPC.downedMoonlord;
        }
        public bool CanShowItemDropInUI() {
            return true;
        }
        public string GetConditionDescription() {
            return Description.Value;
        }
    }
}