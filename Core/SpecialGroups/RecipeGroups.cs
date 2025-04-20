using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SpectreMod.Core.SpecialGroups
{
    public class RecipeGroups : ModSystem
    {
        public static RecipeGroup EvilBagGroup { get; private set; }
        public override void OnModLoad() {
            if (EvilBagGroup == null) {
                AddRecipeGroups();
            }
        }
        
        public override void Unload() {
            EvilBagGroup = null;
        }
        
        public override void AddRecipeGroups() {
            RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " " + Language.GetTextValue("Mods.SpectreMod.EvilBag"), ItemID.EaterOfWorldsBossBag, ItemID.BrainOfCthulhuBossBag);
            RecipeGroup.RegisterGroup("SpectreMod:EvilBag", group);
            EvilBagGroup = group;
        }
    }
}