using SpectreMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.CharmsFragments
{
    public class SlimeCharm : ModItem
    {
        public override void SetDefaults() {
            Item.width = 26;
            Item.height = 32;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.KingSlimeBossBag, 3);
        }
    }
}