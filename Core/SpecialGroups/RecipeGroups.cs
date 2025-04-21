using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SpectreMod.Core.SpecialGroups
{
    public class RecipeGroups : ModSystem
    {
        public static RecipeGroup EvilBagGroup { get; private set; }
        public static RecipeGroup HM3BarGroup { get; private set; }
        public override void OnModLoad() {
            if (EvilBagGroup == null) {
                AddRecipeGroups();
            }
            if (HM3BarGroup == null) {
                AddRecipeGroups();
            }
        }
        
        public override void Unload() {
            EvilBagGroup = null;
            HM3BarGroup = null;
        }
        
        public override void AddRecipeGroups() {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Language.GetTextValue("Mods.SpectreMod.EvilBag"), ItemID.EaterOfWorldsBossBag, ItemID.BrainOfCthulhuBossBag);
            RecipeGroup.RegisterGroup("SpectreMod:EvilBag", group);
            EvilBagGroup = group;
            RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Language.GetTextValue("Mods.SpectreMod.HM3Bar"), ItemID.AdamantiteBar, ItemID.TitaniumBar);
            RecipeGroup.RegisterGroup("SpectreMod:HM3Bar", group2);
            HM3BarGroup = group2;
        }
    }
}