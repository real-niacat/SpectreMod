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
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using Terraria.UI.Chat;

namespace SpectreMod.Content.Items.Charms
{
    public class CharmVortex : ModItem
    {
        internal const long BaseLevelCost = 400000L;
        internal static long LevelCost(int level) => BaseLevelCost * level;
        internal static long CumulativeLevelCost(int level) => BaseLevelCost / 2L * level * (level + 1);
        internal const int MaxLevel = 60; // was 60.

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
            CharmVortex clone = (CharmVortex)base.Clone(item);
            clone.level = level;
            clone.totalDamageModifier = totalDamageModifier;
            return clone;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SpectrePlayermod modPlayer = player.GetModPlayer<SpectrePlayermod>();
            modPlayer.charmVortex = true;
            CharmVortexPlayer charmVortexPlayer = player.GetModPlayer<CharmVortexPlayer>();
            charmVortexPlayer.charmVortex = this;
            player.GetDamage(DamageClass.Ranged) *= 1 + level * 0.1f;
            player.GetModPlayer<CharmVortexPlayer>().IsActive = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "CharmVortex", $"Level: {level}");
            line.OverrideColor = Color.LimeGreen;
            tooltips.Add(line);
            string ProgressKey = "[PROGRESS]";
            TooltipLine progressLine = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Text.Contains(ProgressKey));
            if (progressLine != null)
            {
                long progressToNextLevel = totalDamageModifier - CumulativeLevelCost(level);
                long totalToNextLevel = LevelCost(level + 1);
                double ratio = (double)progressToNextLevel / totalToNextLevel;
                string percent = (100d * ratio).ToString("0.00");
                progressLine.Text = progressLine.Text.Replace(ProgressKey, percent);
            string damageKey = "[RangeDmgInc]";
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
    }
    public class CharmVortexPlayer : ModPlayer
    {
        internal CharmVortex charmVortex = null;
        public bool IsActive = false;
        
        internal void AccumulateDamageModifier(int damage)
        {
            if (charmVortex is null)
                return;
            charmVortex.totalDamageModifier += damage;
            if (charmVortex.level < CharmVortex.MaxLevel && charmVortex.totalDamageModifier > CharmVortex.CumulativeLevelCost(charmVortex.level + 1))
            {
                ++charmVortex.level;
            }
        }
        
        public override void ResetEffects()
        {
            charmVortex = null;
            IsActive = false;
        }
    }
}