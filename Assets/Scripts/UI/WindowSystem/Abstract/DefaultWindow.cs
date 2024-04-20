using System;
using System.Collections.Generic;
using UnityEngine;

namespace FVN.WindowSystem
{
    public abstract class DefaultWindow : MonoBehaviour
    {
        public Action<WindowResult> OnCompleted { get; set; }
        public virtual DefaultWindow Initialize(object obj)
        {
            return this;
        }
        public virtual DefaultWindow WithTitle(string label)
        {
            return this;
        }
        public virtual DefaultWindow SetDescription(string desc)
        {
            return this;
        }
        public virtual DefaultWindow SetBtnsText(List<string> texts)
        {
            return this;
        }
    }
}
