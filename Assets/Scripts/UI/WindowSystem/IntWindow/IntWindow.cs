using UnityEngine;

namespace FVN.WindowSystem
{
    public class IntWindow : DefaultWindow
    {
        [SerializeField] private IntWindowView view;

        public override DefaultWindow Initialize(object obj)
        {
            var config = obj as ISkeletonConfig;
            for (int i = 0; i < view.cards.Count; i++)
            {
                view.cards[i].Initialize(config.Skeletons[i], config.Type);
                view.cards[i].OnChoice = HandleChoice;
            }

            return this;
        }

        public override DefaultWindow WithTitle(string label)
        {
            view.title.text = label;
            return this;
        }


        public void HandleChoice(SkeletonData data, SkeletonType type)
        {
            OnCompleted?.Invoke(new WindowResult()
            {
                obj = new CardResult(data, type)
            });
            Destroy(gameObject);
        }

        public class CardResult
        {
            public SkeletonData data;
            public SkeletonType type;

            public CardResult(SkeletonData data, SkeletonType type)
            {
                this.data = data;
                this.type = type;
            }
        }
    }
}