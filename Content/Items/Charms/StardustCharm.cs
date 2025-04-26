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
    public class StardustCharm : ModItem
    {
        internal const long BaseLevelCost = 400000L;
        internal static long LevelCost(int level) => BaseLevelCost * level;
        internal static long CumulativeLevelCost(int level) => (BaseLevelCost / 2L) * level * (level + 1);
        internal const int MaxLevel = 60; // was 60.

        internal const float ModifierAmount = 0.5f;

        internal int level = 0;
        internal long totalDamageModifier = 0L;
        public long Progression;


        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
            Progression = totalDamageModifier / (1 + BaseLevelCost * level);
        }
        
        public override ModItem Clone(Item item)
        {
            StardustCharm clone = (StardustCharm)base.Clone(item);
            clone.level = level;
            clone.totalDamageModifier = totalDamageModifier;
            return clone;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SpectrePlayermod modPlayer = player.GetModPlayer<SpectrePlayermod>();
            modPlayer.charmStardust = true;
            CharmStardustPlayer charmStardustPlayer = player.GetModPlayer<CharmStardustPlayer>();
            charmStardustPlayer.charmStardust = this;
            player.GetDamage(DamageClass.Summon) *= 1.9f;
            player.maxMinions += 1 + (level / 2);
            player.statManaMax2 += level * 5;
            player.statMana += level * 5;
            player.GetModPlayer<CharmStardustPlayer>().IsActive = true;
        }
        public override void SaveData(TagCompound tag)
        {
            tag["level"] = level;
            tag["totalDamage"] = totalDamageModifier;
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
            writer.Write(level);
            writer.Write(totalDamageModifier);
        }
        public override void NetReceive(BinaryReader reader)
        {
            level = reader.ReadInt32();
            totalDamageModifier = reader.ReadInt64();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "Level", $"Level: {level}/{MaxLevel}");
            line.OverrideColor = Color.LimeGreen;
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
                string damageKey = "[SummonDmgInc]";
                TooltipLine damageLine = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Text.Contains(damageKey));
                if (damageLine != null)
                {
                    damageLine.Text = damageLine.Text.Replace(damageKey, $"{(level * 0.1f) * 100}%");
                }
            }
            line = new TooltipLine(Mod, "Level", $"Bonus Minion Slots: {level}");
            line.OverrideColor = Color.Magenta;
            tooltips.Add(line);
        }
    }
    public class CharmStardustPlayer : ModPlayer
    {
        public StardustCharm charmStardust = null;
        public bool IsActive = false;
        public int SlotModifier = 0;
        public int ManaBoost = 0;
        public int SlotMod;
        public int ManaMod;
        
        /// <summary>
        /// <para/> Adappted code from <see href="https://github.com/CalamityTeam/CalamityModPublic/blob/1.4.4/Items/Accessories/ShatteredCommunity.cs">The Shattered Community</see> from the Calamity Mod.
        /// </summary>
        internal void AccumulateDamageModifier(long damage)
        { 
            if (charmStardust is null)
                return;
            SlotModifier = charmStardust.level;
            ManaBoost = charmStardust.level * 5;
            if (IsActive)    
                charmStardust.totalDamageModifier += damage;
            if (IsActive && charmStardust.level < StardustCharm.MaxLevel && charmStardust.totalDamageModifier > StardustCharm.CumulativeLevelCost(charmStardust.level + 1))
            {
                charmStardust.level++;
                charmStardust.totalDamageModifier = 0L;
            }
        }
        
        

        public override void ModifyMaxStats(out StatModifier health, out StatModifier mana)
        {
            base.ModifyMaxStats(out health, out mana);
            if (IsActive)
            {
                mana.Flat += ManaBoost;
            }
        }

        public override void ResetEffects()
        {
            charmStardust = null;
            IsActive = false;
        }
    }
}