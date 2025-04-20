using MonoMod.Core.Platforms;
using SpectreMod.Content.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpectreMod.Content.Charms
{
    public class CharmDistraught_Base : ModItem
    {
        public override string Texture => "SpectreMod/Common/PlaceHolders/PlaceHolder";

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 0.9f; //i know it's a bit unforgiving but, it says -10% damage, and god damn it im going to make it take away 10% of your damage.
            player.GetModPlayer<CharmDistraughtPlayer>().intensity = 1;
        }
    }

    public class CharmDistraughtPlayer : ModPlayer
    {
        public int intensity;
        public static int[] pool_base = { BuffID.Poisoned, BuffID.Bleeding, BuffID.Slow, BuffID.OnFire, BuffID.Frostburn };
        public static int[] pool_upgr = { BuffID.Ichor, BuffID.Electrified };
        public static int[] pool_max = { BuffID.CursedInferno, ModContent.BuffType<MagmatingDebuff>() };
        //sorry for using 3 different variables

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            base.ModifyHitNPC(target, ref modifiers);

            if (intensity > 0)
            {
                int chance = 40 + (intensity * 20); //really dumb way to do it, but it works ehe
                int[] pool = pool_base;
                if (intensity > 1) { pool.Concat(pool_upgr); }
                if (intensity > 2) { pool.Concat(pool_max); }

                int rnd = Main.rand.Next(100) + 1; //.Next(int) is inclusive to 0 and exclusive to n, adding 1 is useful for what we need.
                if (rnd <= chance)
                {
                    target.AddBuff(pool[Main.rand.Next(pool.Length)], 15);
                }
            }
        }
    }
}
