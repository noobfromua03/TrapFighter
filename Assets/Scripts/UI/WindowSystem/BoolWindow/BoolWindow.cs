using System;
using System.Collections.Generic;
using UnityEngine;

namespace FVN.WindowSystem
{
    public class BoolWindow : DefaultWindow
    {
        [SerializeField] private BoolWindowView view;

        private void Awake()
        {
            view.Btns[0].onClick.AddListener(() =>
            {
                OnCompleted?.Invoke(new WindowResult() { boolResult = false });
                Destroy(gameObject);
            });

            view.Btns[1].onClick.AddListener(() =>
            {
                OnCompleted?.Invoke(new WindowResult() { boolResult = true });
                Destroy(gameObject);
            });
        }

        public override DefaultWindow SetBtnsText(List<string> texts)
        {
            for(int i = 0; i < view.BtnsTMP.Count; i++)
                view.BtnsTMP[i].text = texts[i];
            return this;
        }

        public override DefaultWindow SetDescription(string desc)
        {
            view.Description.text = desc;
            return this;
        }

        public override DefaultWindow WithTitle(string label)
        {
            view.Title.text = label;
            return this;
        }
    }
}
