using Microsoft.Xna.Framework;
using SpectreMod.Common.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace SpectreMod.Common.UI
{
    public class SpectreUIState : UIState
    {
        public override void OnInitialize()
        {
            UIText text = new UIText("missingtext");
            text.Width.Set(80, 0);
            text.Height.Set(80, 0);

            text.HAlign = 0.5f;
            text.VAlign = 0.5f;
            Append(text);
        }

        public override void Update(GameTime gameTime)
        {
            UIText stakes = (UIText)Elements.Find((e) => e is UIText);
            if (Main.LocalPlayer != null)
            {
                stakes.SetText($"Stakes: {Main.LocalPlayer.GetModPlayer<StakesPlayer>().Stakes}");

            }
        }
    }
}
