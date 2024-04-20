using System.Collections.Generic;
using UnityEngine;

namespace FVN.WindowSystem
{
    public class Windows : MonoBehaviour
    {
        public static Windows Instance { get; private set; }

        [SerializeField] private OkWindow okWindowPrefab;
        [SerializeField] private BoolWindow boolWindowPrefab;
        [SerializeField] private IntWindow intWindowPrefab;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public static DefaultWindow OkWindow(string title, string desc, string btnText)
            => InitializeWindow(Instance.okWindowPrefab.gameObject, title, desc, new List<string> { btnText });

        public static DefaultWindow BoolWindow(string title, string desc, List<string> btnTexts)
            => InitializeWindow(Instance.boolWindowPrefab.gameObject, title, desc, btnTexts);

        public static DefaultWindow IntWindow(string title, ISkeletonConfig config)
            => InitializeWindow(Instance.intWindowPrefab.gameObject, title, "", new List<string>() { })
                 .Initialize(config);

        private static DefaultWindow InitializeWindow(GameObject windowPrefab, string title, string desc, List<string> btnTexts)
            => Instantiate(windowPrefab, Instance.transform)
                .GetComponent<DefaultWindow>()
                .WithTitle(title)
                .SetDescription(desc)
                .SetBtnsText(btnTexts);
    }
}