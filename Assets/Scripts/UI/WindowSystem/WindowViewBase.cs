﻿using TMPro;
using UnityEngine;

namespace FVN.WindowSystem
{
    public class WindowViewBase : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text Title { get; private set; }
        [field: SerializeField] public TMP_Text Description { get; private set; }
    }
}
