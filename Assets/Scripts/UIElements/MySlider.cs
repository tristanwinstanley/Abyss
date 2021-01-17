using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts.UIElements
{
    public class MySlider : MonoBehaviour
    {
        public Slider slider;
        public void SetMaxValue(int maxValue)
        {
            slider.maxValue = maxValue;
        }
        public void SetMaxValue(float maxValue)
        {
            slider.maxValue = maxValue;
        }
        public void SetValue(int value)
        {
            slider.value = value;
        }
        public void AddValue(int value)
        {
            slider.value += value;
        }
        public void AddValue(float value)
        {
            slider.value += value;
        }
    }
}
    
