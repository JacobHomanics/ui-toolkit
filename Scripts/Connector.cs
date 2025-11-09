using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JacobHomanics.UI;

namespace JacobHomanics.UI {
    public abstract class Connector : MonoBehaviour
    {
        public abstract float CurrentNum { get; }
        public abstract float MaxNum { get; }
    }
}
