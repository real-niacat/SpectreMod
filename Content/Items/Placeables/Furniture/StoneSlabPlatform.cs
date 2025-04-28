using SpectreMod.Content.Tiles.Furniture;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Items.Placeables.Furniture
{
    public class StoneSlabPlatform : ModItem
    {
        public override void SetStaticDefaults() {
            Item.ResearchUnlockCount = 200;
        }

        public override void SetDefaults() {
            Item.DefaultToPlaceableTile(ModContent.TileType<StoneSlabPlatformTile>());
            Item.width = 8;
            Item.height = 10;
        }

        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.StoneSlab, 1);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
    }
}