using Terraria;
using Terraria.ModLoader;

namespace SpectreMod.Common.Players
{
    public class SlimeCharmEffect : ModPlayer
    {
        public bool HasSlimeCharm;

        // Always reset the accessory field to its default value here.
        public override void ResetEffects() {
            HasSlimeCharm = false;
        }

        // Vanilla applies immunity time before this method and after PreHurt and Hurt
        // Therefore, we should apply our immunity time increment here
        public override void PostHurt(Player.HurtInfo info) {
            // Here we increase the player's immunity time by 1 second when Slime Charm is equipped
            if (!HasSlimeCharm) {
                return;
            }

            // Different cooldownCounter values mean different damage types taken and different cooldown slots
            // See ImmunityCooldownID for a list.
            // Don't apply extra immunity time to pvp damage (like vanilla)
            if (!info.PvP) {
                Player.AddImmuneTime(info.CooldownCounter, 150);
            }
        }
    }
}