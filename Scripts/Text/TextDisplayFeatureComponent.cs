using UnityEngine;
using TMPro;

namespace JacobHomanics.UI
{
    public class TextDisplayFeatureComponent : BaseCurrentMaxComponent
    {
        public TMP_Text text;

        public enum DisplayType
        {
            Current, Max, Difference
        }

        public DisplayType displayType;
        public string format = "#,##0";

        void Update()
        {
            Display(displayType, Current, Max);
        }

        public void Display(DisplayType displayType, float current, float max)
        {
            if (displayType == DisplayType.Current)
                Display(text, current, format);
            if (displayType == DisplayType.Max)
                Display(text, max, format);
            if (displayType == DisplayType.Difference)
                Display(text, max - current, format);
        }

        public void Display(TMP_Text text, float num, string format)
        {
            text.text = num.ToString(format);
        }
    }
}
