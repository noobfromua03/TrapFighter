using System;
using TMPro;
using UnityEngine;

public class SkeletonCardView : MonoBehaviour
{
    [SerializeField] private TMP_Text description;

    public Action<SkeletonData, SkeletonType> OnChoice;

    private SkeletonData data;
    private SkeletonType type;

    public void Initialize(SkeletonData data, SkeletonType type)
    {
        description.text = data.description;
        this.type = type;
        this.data = data;
    }

    public void OnClick()
    {
        OnChoice?.Invoke(data, type);
    }
}
