using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Materials
{
    public class DrakomireScale : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.rare = ItemRarityID.Green;
        }
    }
}