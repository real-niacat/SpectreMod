using SpectreMod.Content.Materials;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmSol : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/CharmPlaceholder";
        
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 1.9f;
            player.GetModPlayer<CharmSolPlayer>().intensity = 1;
        }
    }
    
    public class CharmSolPlayer : ModPlayer
    {
        public int intensity;
       
    }
}