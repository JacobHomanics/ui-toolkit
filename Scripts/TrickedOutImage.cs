using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JacobHomanics.UI;

namespace JacobHomanics.UI {

    public class TrickedOutImage : MonoBehaviour
    {
        [SerializeField] private Image image;

        public Image Image
        {
            get => image;
        }

        [SerializeReference]
        private List<FeatureToggle> featureToggles = new List<FeatureToggle>
        {
            new TextDisplayFeature2(),
            new ColorGradientFeature(),
            new BackgroundFillFeature(),
            new FlashingFeature()
        };

        public Connector connector;

        public float CurrentNum => connector.CurrentNum;
        public float MaxNum => connector.MaxNum;

        public bool reverseFill;

        private float previousValue;

        private void Awake()
        {
            previousValue = CurrentNum;
        }

        void Update()
        {
            Debug.Log(reverseFill);
            if (reverseFill)
                image.fillAmount = (MaxNum - CurrentNum) / MaxNum;
            else
                image.fillAmount = CurrentNum / MaxNum;



            UIToolkit.Display(UIToolkit.GetFeature<TextDisplayFeature2>(featureToggles), CurrentNum, MaxNum);

            UIToolkit.ColorGradientFeatureCommand(UIToolkit.GetFeature<ColorGradientFeature>(featureToggles), image, CurrentNum, MaxNum);

            UIToolkit.FlashingFeatureCommand(UIToolkit.GetFeature<FlashingFeature>(featureToggles), CurrentNum, MaxNum);

            UIToolkit.HandleValueChange(CurrentNum, UIToolkit.GetFeature<BackgroundFillFeature>(featureToggles), ref previousValue, MaxNum);
            UIToolkit.UpdateBackgroundFillAnimation(UIToolkit.GetFeature<BackgroundFillFeature>(featureToggles), MaxNum);
        }

    }
}
