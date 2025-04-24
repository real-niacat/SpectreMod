using SpectreMod.Content.Buffs;
using SpectreMod.Content.Materials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.NetModules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Net;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmSol : ModItem
    {
        
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
            player.GetModPlayer<CharmSolPlayer>().MeleeSize = 3;
            player.GetModPlayer<CharmSolPlayer>().PlayerSpeed = 1;
            player.GetModPlayer<CharmSolPlayer>().MountSpeed = 1;
            player.GetModPlayer<CharmSolPlayer>().IsActive = true;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DrakomireFang>(), 30);
            recipe.AddIngredient(ModContent.ItemType<DrakomireScale>(), 20);
            recipe.AddIngredient(ItemID.LunarTabletFragment, 25);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
    
    public class CharmSolPlayer : ModPlayer
    {
        public int KillCount;
        public int KillNumRequired = 100;
        public int intensity = 0;
        public int MountSpeed = 0;
        public int MountSpeedMod = 1;
        public int PlayerSpeed = 0;
        public int PlayerSpeedMod = 1;
        public int MeleeSize = 0;
        public int MeleeSizeMod = 1;
        public int scalemod;
        public bool IsActive = false;
        
        public void RegisterKill(NPC npc)
        {
            if (npc.type == NPCID.SolarDrakomire)
            {
                KillCount++;
                if (KillCount >= KillNumRequired)
                {
                    PlayerSpeedMod++;
                    MountSpeed++;
                    MeleeSizeMod++;
                    if (KillNumRequired >= 1000)
                    {
                        KillNumRequired += 500;
                    }
                    else
                    {
                        KillNumRequired += 100;
                    }
                }
            }
        }
        public override void ModifyItemScale(Item item, ref float scale)
        {
            base.ModifyItemScale(item, ref scale);
            if (IsActive)
                {
                scale *= MeleeSize + (MeleeSizeMod * 100f);
                }
                else
                {
                    scale = 1;
                }
            scalemod = (int)scale;
        }
        
        public override void PostUpdateRunSpeeds()
        {
            base.PostUpdateRunSpeeds();
            if (IsActive)
            {
                Player.accRunSpeed *= 1 + (PlayerSpeed + (PlayerSpeedMod * 2f));
                Player.maxRunSpeed *= 1 + (MountSpeed + (MountSpeedMod * 2f));
            }
            else
            {
                Player.accRunSpeed *= 1;
                Player.maxRunSpeed *= 1;
            }
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            base.ModifyHitNPC(target, ref modifiers);
            if (Player.magmaStone && IsActive)
            {
                target.AddBuff(ModContent.BuffType<MagmatingDebuff>(), 15 * 60);
            }
        }
        public override void ResetEffects()
        {
            base.ResetEffects();
            PlayerSpeed = 0;
            MountSpeed = 0;
            IsActive = false;
        }
    }
}