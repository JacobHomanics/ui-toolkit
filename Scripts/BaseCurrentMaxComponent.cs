using UnityEngine;
using TMPro;

namespace JacobHomanics.UI
{
    public class BaseCurrentMaxComponent : MonoBehaviour
    {
        public float Current => GetComponentInParent<BaseCurrentMaxConnector>().CurrentNum;
        public float Max => GetComponentInParent<BaseCurrentMaxConnector>().MaxNum;
    }
}
