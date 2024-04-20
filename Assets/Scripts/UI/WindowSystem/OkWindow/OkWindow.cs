using System;
using System.Collections.Generic;
using UnityEngine;

namespace FVN.WindowSystem
{
    public class OkWindow : DefaultWindow
    {
        [SerializeField] private OkWindowView view;

        private void Awake()
        {
            view.Btn.onClick.AddListener(() =>
            {
                OnCompleted?.Invoke(new WindowResult());
                Destroy(gameObject);
            });
        }

        public override DefaultWindow WithTitle(string title)
        {
            view.Title.text = title;
            return this;
        }

        public override DefaultWindow SetDescription(string desc)
        {
            view.Description.text = desc;
            return this;
        }

        public override DefaultWindow SetBtnsText(List<string> texts)
        {
            view.BtnTMP.text = texts[0];
            return this;
        }
    }
}
