using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SoulsLikeTutorial
{
    public class StatMeter : MonoBehaviour
    {
        public Slider slider;

        public void SetMax(float maxValue)
        {
            slider.maxValue = maxValue;
            slider.value = maxValue;
        }

        public void SetValue(float value)
        {
            slider.value = value;
        }
    }
}
