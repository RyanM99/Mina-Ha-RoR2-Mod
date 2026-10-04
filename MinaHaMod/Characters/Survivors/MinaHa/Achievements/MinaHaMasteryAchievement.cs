using RoR2;
using MinaHaMod.Modules.Achievements;

namespace MinaHaMod.Survivors.MinaHa.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class MinaHaMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = MinaHaSurvivor.MINAHA_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = MinaHaSurvivor.MINAHA_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => MinaHaSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}