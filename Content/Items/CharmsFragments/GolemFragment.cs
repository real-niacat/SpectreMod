using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Items.CharmsFragments
{
    public class GolemFragment : ModItem
    {
        public override void SetDefaults() {
            Item.width = 13;
            Item.height = 16;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1);
        }
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmFragmentPlaceholder";

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GolemBossBag, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}