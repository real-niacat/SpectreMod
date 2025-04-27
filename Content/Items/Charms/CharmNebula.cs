using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpectreMod.Content.Buffs;
using SpectreMod.Content.Items.Materials;
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
    public class CharmNebula : ModItem
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
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
        }
        
        public override ModItem Clone(Item item)
        {
            CharmNebula clone = (CharmNebula)base.Clone(item);
            clone.level = level;
            clone.totalDamageModifier = totalDamageModifier;
            return clone;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            SpectrePlayermod modPlayer = player.GetModPlayer<SpectrePlayermod>();
            modPlayer.charmNebula = true;
            CharmNebulaPlayer charmNebulaPlayer = player.GetModPlayer<CharmNebulaPlayer>();
            charmNebulaPlayer.charmNebula = this;
            player.GetDamage(DamageClass.Magic) += level * 0.125f;
            player.statManaMax2 += level * 5;
            player.statMana += level * 5;
            player.GetModPlayer<CharmNebulaPlayer>().IsActive = true;
        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine line = new TooltipLine(Mod, "CharmNebula", $"Level: {level}/{MaxLevel}");
            line.OverrideColor = Color.Cyan;
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
                string damageKey = "[MageDmgInc]";
                TooltipLine damageLine = tooltips.FirstOrDefault(x => x.Mod == "Terraria" && x.Text.Contains(damageKey));
                    if (damageLine != null)
                    {
                        damageLine.Text = damageLine.Text.Replace(damageKey, $"{(level * 0.125f) * 100}%");
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
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PinkMatter>(), 10);
            recipe.AddIngredient(ModContent.ItemType<NebulaBeastClaw>(), 15);
            recipe.AddIngredient(ItemID.Ectoplasm, 50);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
    public class CharmNebulaPlayer : ModPlayer
    {
        internal CharmNebula charmNebula = null;
        public bool IsActive = false;
        
        internal void AccumulateDamageModifier(int damage)
        {
            if (charmNebula is null)
                return;
            charmNebula.totalDamageModifier += damage;
            if (charmNebula.level < CharmNebula.MaxLevel && charmNebula.totalDamageModifier > CharmNebula.CumulativeLevelCost(charmNebula.level + 1))
            ++charmNebula.level;
        }
        public override void ResetEffects()
        {
            charmNebula = null;
            IsActive = false;
        }
    }
}