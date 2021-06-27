using Assets.Scripts.Enemies.BaseEntityScripts;

namespace Assets.Scripts.Player
{
    public class PlayerExperienceController : ExperienceController
    {
        protected override void LevelUp()
        {
            level++;
            SkillPoints++;
        }
    }
}
