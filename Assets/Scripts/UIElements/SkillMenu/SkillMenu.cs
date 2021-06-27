using UnityEngine;
using Assets.Scripts.Utility;
using Assets.Scripts.Enemies.BaseEntityScripts;
using UnityEngine.UI;

namespace Assets.Scripts.UIElements.SkillMenu
{
    public class SkillMenu : MonoBehaviour
    {
        [SerializeField] private Text skillPointsValue;
        private GameObject player;
        private ExperienceController experienceController;
        public int PointsToSpend { get; private set; }
        private void Start()
        {
            player = GameObject.FindWithTag(Constants.PLAYER_TAG);
            experienceController = player.GetComponent<ExperienceController>();
            PointsToSpend = 3;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            //PointsToSpend = experienceController.SkillPoints; // need to change this, when player levels up this should ++
            skillPointsValue.text = PointsToSpend.ToString();
        }
        

        public void Remove1SkillPoint()
        {
            PointsToSpend--;
        }
        public void AddSkillPoint(int x = 1)
        {
            PointsToSpend += x;
        }
    }
}
