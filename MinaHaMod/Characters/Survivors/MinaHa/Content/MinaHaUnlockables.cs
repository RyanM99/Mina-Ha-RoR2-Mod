using MinaHaMod.Survivors.MinaHa.Achievements;
using RoR2;
using UnityEngine;

namespace MinaHaMod.Survivors.MinaHa
{
    public static class MinaHaUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                MinaHaMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(MinaHaMasteryAchievement.identifier),
                MinaHaSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
