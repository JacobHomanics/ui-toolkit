using UnityEngine;
using UnityEngine.UI;

namespace JacobHomanics.UI
{
    public class FillSliderFeatureComponent : BaseCurrentMaxComponent
    {
        public Slider slider;
        void Update()
        {
            slider.value = Current;
            slider.maxValue = Max;
        }
    }
}