using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace MinaHaMod.Survivors.MinaHa
{
    internal static class RakeEffects
    {
        internal static DamageAPI.ModdedDamageType rakeDamageType;
        private static bool initialized;
        internal static void Init()
        {
            if (initialized)
                return;

            initialized = true;
            rakeDamageType = DamageAPI.ReserveDamageType();

            On.RoR2.HealthComponent.TakeDamage += AddMissingHealthDamage;
            GlobalEventManager.onCharacterDeathGlobal += HealOnKill;
        }

        private static void AddMissingHealthDamage(
            On.RoR2.HealthComponent.orig_TakeDamage orig,
            HealthComponent victim,
            DamageInfo damageInfo)
        {
            if (NetworkServer.active
                && victim.alive
                && DamageAPI.HasModdedDamageType(
                    damageInfo, rakeDamageType))
            {
                float missingHealth =
                    Mathf.Max(0f, victim.fullHealth - victim.health);

                damageInfo.damage += missingHealth * MinaHaStaticValues.rakeMissingHealthDamagePercent;
            }

            orig(victim, damageInfo);
        }

        private static void HealOnKill(DamageReport report)
        {
            if (!NetworkServer.active
                || report == null
                || !DamageAPI.HasModdedDamageType(
                    report.damageInfo, rakeDamageType))
                return;

            CharacterBody attacker = report.attackerBody;
            if (!attacker || !attacker.healthComponent)
                return;

            HealthComponent health = attacker.healthComponent;
            if (!health.alive)
                return;

            health.Heal(
                health.fullHealth * MinaHaStaticValues.rakeHealOnKillPercent,
                default(ProcChainMask),
                true);
        }
    }
}