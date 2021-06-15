using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Enemies.BaseEntityScripts
{
    public class ExperienceController : MonoBehaviour
    {
        [SerializeField]
        private int experience;
        [SerializeField]
        private float level;
        #region Special methods
        private void Awake()
        {
            level = 1;
            experience = 0;
        }
        private void Update()
        {
            LevelUp();
        }
        #endregion

        #region private methods
        private void LevelUp()
        {
            if (experience >= 10)
            {
                level++;
                experience = 0;
            }
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

