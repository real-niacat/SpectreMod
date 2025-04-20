using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace SpectreMod.Content.Charms
{
    public class CharmDistraught_Upgraded : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";

        public override void SetDefaults()
        {
            //this is copied code from myself
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 0.93f;
            player.GetModPlayer<CharmDistraughtPlayer>().intensity = 2;
        }
    }
}
