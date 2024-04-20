using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FVN.WindowSystem
{
    public class BoolWindowView : WindowViewBase
    {
        [field: SerializeField] public List<Button> Btns { get; private set; }
        [field: SerializeField] public List<TMP_Text> BtnsTMP { get; private set; }
    }
}
