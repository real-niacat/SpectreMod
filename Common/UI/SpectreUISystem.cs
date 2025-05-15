using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace SpectreMod.Common.UI
{
    public class SpectreUISystem : ModSystem
    {
        internal UserInterface Interface;
        internal SpectreUIState UI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                Interface = new UserInterface();
                UI = new SpectreUIState();
                UI.Activate();
            }
        }

        public override void Unload()
        {
            UI = null; //probably unsafe!
        }

        private GameTime _lastUpdate;

        public override void UpdateUI(GameTime gameTime)
        {
            _lastUpdate = gameTime;
            if (Interface?.CurrentState != null)
            {
                Interface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "MyMod: MyInterface",
                    delegate
                    {
                        if (_lastUpdate != null && Interface?.CurrentState != null)
                        {
                            Interface.Draw(Main.spriteBatch, _lastUpdate);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        internal void Show()
        {
            Interface?.SetState(UI);
        }

        internal void Hide()
        {
            Interface?.SetState(null);
        }
    }
}
