using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class ExperienceController : MonoBehaviour
    {
        [SerializeField] public int SkillPoints { get; protected set; }
        [SerializeField] protected int level;
        [SerializeField] private int experience;
        [SerializeField] private int experienceCap = 10; // harcoding to 10 for now, will need a dynamic experience cap in the future
        #region Special methods
        private void Awake()
        {
            level = 1;
            experience = 0;
        }
        private void Update()
        {
            CheckExperience();
        }
        #endregion

        #region private/protected methods
        private void CheckExperience()
        {
            if (experience >= experienceCap)
            {
                LevelUp();
                experience = 0;
            }
        }
        protected virtual void LevelUp()
        {
            level++;
        }
        #endregion

        #region public methods
        public void AddExperience(int xp)
        {
            experience += xp;
        }
        #endregion
    }
}

