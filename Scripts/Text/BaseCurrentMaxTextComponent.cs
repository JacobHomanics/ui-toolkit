using UnityEngine;
using TMPro;

namespace JacobHomanics.UI
{
    [System.Serializable]
    public class TextProperties
    {
        public TMP_Text text;

        public enum DisplayType
        {
            Current, Max, Difference
        }

        public DisplayType displayType;
        public string format = "#,##0";
    }

    public abstract class BaseCurrentMaxTextComponent : BaseCurrentMaxComponent
    {

        public void Display(TMP_Text text, TextProperties.DisplayType displayType, float current, float max, string format)
        {
            if (displayType == TextProperties.DisplayType.Current)
                Display(text, current, format);
            if (displayType == TextProperties.DisplayType.Max)
                Display(text, max, format);
            if (displayType == TextProperties.DisplayType.Difference)
                Display(text, max - current, format);
        }

        public void Display(TMP_Text text, float num, string format)
        {
            text.text = num.ToString(format);
        }
    }
}
