using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIElements.SkillMenu
{
    public class Skill : MonoBehaviour
    {
        private int skillLevel;
        private SkillMenu skillMenu;
        [SerializeField] private Button minusBtn;
        [SerializeField] private Button plusBtn;
        [SerializeField] private Text skillLevelText;
        private void Start()
        {
            skillMenu = transform.GetComponentInParent<SkillMenu>();
            skillLevelText.text = skillLevel.ToString();
        }
        public void PlusButtonPressed()
        {
            ChangeSkillRank(1);
        }
        public void MinusButtonPressed()
        {
            ChangeSkillRank(-1);
        }

        private void ChangeSkillRank(int i)
        {
            skillLevel += i;
            skillMenu.AddSkillPoint(-i);
        }
        private void Update()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            //todo should move this to skillMenu otherwise this will be called on every new skill
            skillLevelText.text = skillLevel.ToString();

            if (skillMenu.PointsToSpend <= 0)
            {
                plusBtn.interactable = false;
            }
            else
            {
                plusBtn.interactable = true;
            }

            if (skillLevel <= 0)
            {
                minusBtn.interactable = false;
            }
            else
            {
                minusBtn.interactable = true;
            }
        }
    }
}
