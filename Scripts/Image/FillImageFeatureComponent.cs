using JacobHomanics.UI;
using UnityEngine;
using UnityEngine.UI;

namespace JacobHomanics.UI
{
    public class FillImageFeatureComponent : BaseCurrentMaxComponent
    {
        [SerializeField] private Image image;

        public Image Image
        {
            get => image;
        }
        public bool reverseFill;

        void Update()
        {
            UpdateImage(Image, Current, Max);
        }

        private void UpdateImage(Image image, float current, float max)
        {
            if (reverseFill)
                image.fillAmount = (max - current) / max;
            else
                image.fillAmount = current / max;
        }
    }

}
