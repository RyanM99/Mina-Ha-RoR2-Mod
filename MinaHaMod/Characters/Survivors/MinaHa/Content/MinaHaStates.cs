using MinaHaMod.Survivors.MinaHa.SkillStates;

namespace MinaHaMod.Survivors.MinaHa
{
    public static class MinaHaStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(SlashCombo));

            Modules.Content.AddEntityState(typeof(Shoot));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(ThrowBomb));

            Modules.Content.AddEntityState(typeof(NewMoney));

            Modules.Content.AddEntityState(typeof(Rake));
        }
    }
}
