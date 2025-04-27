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
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmSol : ModItem
    {
        
        internal const long BaseLevelCost = 400000L;
        internal static long LevelCost(int level) => BaseLevelCost * level;
        internal static long CumulativeLevelCost(int level) => BaseLevelCost / 2L * level * (level + 1);
        internal const int MaxLevel = 60;
        
        internal const float ModifierAmount = 0.5f;
        
        internal int level = 0;
        internal long totalDamageModifier = 0L;
        
        
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
        }
        
        public override ModItem Clone(Item item)
        {
            var clone = (CharmSol)base.Clone(item);
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
            player.GetDamage(DamageClass.Melee) += level * 0.125f;
            player.GetModPlayer<CharmSolPlayer>().MeleeSize = 3;
            player.GetModPlayer<CharmSolPlayer>().PlayerSpeed = 1;
            player.GetModPlayer<CharmSolPlayer>().MountSpeed = 1;
            player.GetModPlayer<CharmSolPlayer>().IsActive = true;
            modPlayer.MeleeSizeMod += level * ModifierAmount;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "Level", $"Level: {level}");
            line.OverrideColor = Color.Gold;
            tooltips.Add(line);
            string ProgressKey = "[PROGRESS]";
            TooltipLine progressLine = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Text.Contains(ProgressKey));
            if (progressLine != null)
            {
                if (level < MaxLevel)
                {
                    long progressToNextLevel = totalDamageModifier - CumulativeLevelCost(level);
                    long totalToNextLevel = LevelCost(level + 1);
                    double ratio = (double)progressToNextLevel / totalToNextLevel;
                    string percent = (100D * ratio).ToString("0.00");
                    progressLine.Text = progressLine.Text.Replace(ProgressKey, percent);
                }
                else
                {
                    progressLine.Text = string.Empty;
                }
                string damageKey = "[MeleeDMGinc]";
                TooltipLine damageLine = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Text.Contains(damageKey));
                if (damageLine != null)
                {
                    damageLine.Text = damageLine.Text.Replace(damageKey, $"{(level * 0.1f) * 100}%");
                }
            }
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
                level = MaxLevel;
            totalDamageModifier = tag.GetLong("totalDamage");
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(level);
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
        public int DamageAmt;
        public bool IsActive = false;
        
        /// <summary>
        /// <para/> Adappted code from <see href="https://github.com/CalamityTeam/CalamityModPublic/blob/1.4.4/Items/Accessories/ShatteredCommunity.cs">The Shattered Community</see> from the Calamity Mod.
        /// </summary>
        internal void AccumulateDamageModifier(long damage)
        {
            if (charmSol is null)
                return;
            
            // Actually accumulate the damage.
            charmSol.totalDamageModifier += damage;
            MeleeSizeMod = charmSol.level;
            if (charmSol.level < CharmSol.MaxLevel && charmSol.totalDamageModifier > CharmSol.CumulativeLevelCost(charmSol.level + 1))
            {
                ++charmSol.level;
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
                Player.accRunSpeed += 1 + (PlayerSpeed + (Player.maxRunSpeed / 3f));
                Player.maxRunSpeed += 1 + (MountSpeed + (PlayerSpeedMod / 1.75f));
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