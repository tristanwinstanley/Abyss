using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts.UIElements
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public void SetMaxValue(int maxValue)
        {
            slider.maxValue = maxValue;
        }
        public void SetValue(int health)
        {
            slider.value = health;
        }
    }
}
    
