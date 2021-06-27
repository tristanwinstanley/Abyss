using UnityEngine;

namespace Assets.Scripts.UIElements
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject skillMenu;

        private void Update()
        {
            ShowOrHideMenus();
        }
        private void ShowOrHideMenus()
        {
            if (Input.GetKeyDown("k"))
            {
                ShowOrHideMenu(skillMenu);
            }
            else if (Input.GetKeyDown("i"))
            {
                // future menu to come
            }
        }
        private void ShowOrHideMenu(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
