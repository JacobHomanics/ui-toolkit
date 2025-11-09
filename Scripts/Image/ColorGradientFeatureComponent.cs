using UnityEngine;
using UnityEngine.UI;

namespace JacobHomanics.UI
{
    /// <summary>
    /// MonoBehaviour component that applies a color gradient to an image based on current and max values.
    /// </summary>
    public class ColorGradientFeatureComponent : BaseCurrentMaxComponent
    {
        public Image image;
        public Color colorAtMin = Color.red;
        public Color colorAtHalfway = Color.yellow;
        public Color colorAtMax = Color.green;
        public bool reverseFill;

        void Update()
        {
            ColorGradientFeatureCommand(colorAtMin, colorAtHalfway, colorAtMax, reverseFill, image, Current, Max);
        }

        public static void ColorGradientFeatureCommand(Color colorAtMin, Color colorAtHalfway, Color colorAtMax, bool reverseFill, Image image, float current, float max)
        {
            float healthPercent;

            if (reverseFill)
                healthPercent = (max - current) / max;
            else
                healthPercent = current / max;

            Color healthColor;
            if (healthPercent > 0.5f)
            {
                // Green to yellow
                float t = (healthPercent - 0.5f) * 2f;
                healthColor = Color.Lerp(colorAtHalfway, colorAtMax, t);
            }
            else
            {
                // Yellow to red
                float t = healthPercent * 2f;
                healthColor = Color.Lerp(colorAtMin, colorAtHalfway, t);
            }

            image.color = healthColor;
        }
    }
}

