using SpectreMod.Content.Items.Charms;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.ModLoader.IO;

namespace SpectreMod.Core.ModExtend
{
    public partial class PowerCharm : ModPlayer
    {
        public List<PowerCharm> EquippedCharms = [];
        
        public override void ResetEffects()
        {
            EquippedCharms.Clear();
        }
        public virtual void setDefaults()
        {
        }
        
    }
}