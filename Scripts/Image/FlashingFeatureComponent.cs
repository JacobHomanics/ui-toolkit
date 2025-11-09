using UnityEngine;
using UnityEngine.UI;

namespace JacobHomanics.UI
{
    /// <summary>
    /// MonoBehaviour component that creates a flashing effect when a value falls below a threshold.
    /// </summary>
    public class FlashingFeatureComponent : BaseCurrentMaxComponent
    {
        public Image flashImage;
        public float thresholdPercent = 0.2f;
        public Color flashColor1 = Color.red;
        public Color flashColor2 = Color.white;
        public float flashSpeed = 15f;

        public bool reverseFill;

        void Update()
        {
            FlashingFeatureCommand(flashImage, reverseFill, thresholdPercent, flashColor1, flashColor2, flashSpeed, Current, Max);
        }

        public static void FlashingFeatureCommand(Image image, bool reverseFill, float thresholdPercent, Color flashColor1, Color flashColor2, float flashSpeed, float current, float max)
        {
            float healthPercent;

            if (reverseFill)
                healthPercent = (max - current) / max;
            else
                healthPercent = current / max;


            healthPercent = Mathf.Clamp01(healthPercent);

            image.enabled = healthPercent < thresholdPercent;


            if (healthPercent < thresholdPercent)
            {
                float flashValue = Mathf.Sin(Time.time * flashSpeed) * 0.5f + 0.5f;
                Color flashColor = Color.Lerp(flashColor1, flashColor2, flashValue);
                image.color = flashColor;
                image.fillAmount = healthPercent;
            }
        }

    }
}

