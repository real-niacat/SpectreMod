using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpectreMod.Content.Buffs;
using SpectreMod.Content.Materials;
using SpectreMod.Core.usermodifier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.NetModules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmSol : ModItem
    {
        
        internal const long BaseLevelCost = 400000L;
        internal static long LevelCost(int level) => BaseLevelCost * level;
        internal static long CumulativeLevelCost(int level) => (BaseLevelCost / 2L) * level * (level + 1);
        internal const int MaxLevel = 60; // was 60.
        
        internal const float ModifierAmount = 0.5f;
        
        internal int level = 0;
        internal long totalDamageModifier = 0L;
        
        
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        
        public override ModItem Clone(Item item)
        {
            CharmSol clone = (CharmSol)base.Clone(item);
            clone.level = level;
            clone.totalDamageModifier = totalDamageModifier;
            return clone;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SpectrePlayermod modPlayer = player.GetModPlayer<SpectrePlayermod>();
            modPlayer.charmSol = true;
            CharmSolPlayer charmSolPlayer = player.GetModPlayer<CharmSolPlayer>();
            charmSolPlayer.charmSol = this;
            player.GetDamage(DamageClass.Generic) *= 1.9f;
            player.GetModPlayer<CharmSolPlayer>().MeleeSize = 3;
            player.GetModPlayer<CharmSolPlayer>().PlayerSpeed = 1;
            player.GetModPlayer<CharmSolPlayer>().MountSpeed = 1;
            player.GetModPlayer<CharmSolPlayer>().IsActive = true;
            modPlayer.MeleeSizeMod += level * ModifierAmount;
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Add("level", level);
            tag.Add("totalDamage", totalDamageModifier);
        }
        
        public override void LoadData(TagCompound tag)
        {
            level = tag.GetInt("level");
            if (level > MaxLevel)
            {
                level = MaxLevel;
            }
            totalDamageModifier = tag.GetLong("totalDamage");
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write((byte)level);
            writer.Write(totalDamageModifier);
        }
        public override void NetReceive(BinaryReader reader)
        {
            level = reader.ReadInt32();
            totalDamageModifier = reader.ReadInt64();
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
        internal CharmSol charmSol = null;
        public int intensity = 0;
        public int MountSpeed = 0;
        public int MountSpeedMod = 1;
        public int PlayerSpeed = 0;
        public int PlayerSpeedMod = 1;
        public int MeleeSize = 0;
        public int MeleeSizeMod = 1;
        public int scalemod;
        public bool IsActive = false;
        
        internal void AccumulateDamageModifier(long damage)
        {
            if (charmSol is null)
                return;
            
            // Actually accumulate the damage.
            charmSol.totalDamageModifier += damage;
            MeleeSizeMod =  charmSol.level;
            if (charmSol.level < CharmSol.MaxLevel && charmSol.totalDamageModifier > CharmSol.LevelCost(charmSol.level + 1))
            {
                ++charmSol.level;
                charmSol.totalDamageModifier = 0L;
                if (charmSol.level > CharmSol.MaxLevel)
                    charmSol.level = CharmSol.MaxLevel;
                    Main.NewText($"Charm Sol Level Up! {charmSol.level}");
            }
        }
        
        public override void ModifyItemScale(Item item, ref float scale)
        {
            if (IsActive)
                {
                scale *= MeleeSize + (MeleeSizeMod / 2f);
                }
                else
                {
                    scale = 1;
                }
            scalemod = (int)scale;
        }
        
        public override void PostUpdateRunSpeeds()
        {
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
            if (Player.magmaStone && IsActive)
            {
                target.AddBuff(ModContent.BuffType<MagmatingDebuff>(), 15 * 60);
            }
        }
        public override void ResetEffects()
        {
            charmSol = null;
            PlayerSpeed = 0;
            MountSpeed = 0;
            IsActive = false;
        }
    }
}