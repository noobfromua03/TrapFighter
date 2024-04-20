using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FVN.WindowSystem
{
    public class OkWindowView : WindowViewBase
    {
        [field: SerializeField] public Button Btn { get; private set; }
        [field: SerializeField] public TMP_Text BtnTMP { get; private set; }
    }
}
