using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Numerics;

namespace SpectreMod.Content.Items.Tools
{
    public class HimboAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Himbo Axe");
            // Tooltip.SetDefault("A big axe for a big
        }
        
        public int Progression = 200;
        public int damage;
        public int DamageMod;
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 35;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.axe = Progression; // Axe power
            Item.damage = 25; // Damage dealt by the axe
            Item.knockBack = 6; // Knockback power
            Item.value = Item.buyPrice(gold: 10); // Value of the item in copper coins
            Item.rare = ItemRarityID.Green; // Rarity of the item
            DamageMod = Item.axe;
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            base.ModifyWeaponDamage(player, ref damage);
            if (player.HeldItem.type == Item.type)
            {
                damage += DamageMod / 20; // Increase damage by 20% of axe power
            }
        }
        
        public virtual new Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0); // No offset
        }
        
        
        
        public override void AddRecipes()
        {
           Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ItemID.StoneSlab, 50);
                recipe.AddIngredient(ItemID.BorealWood, 20);
                recipe.AddIngredient(ItemID.DynastyWood, 20);
                recipe.AddTile(TileID.Anvils);
                recipe.Register();
        }
    }
}