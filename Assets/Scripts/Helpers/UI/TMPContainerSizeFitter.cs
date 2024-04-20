using TMPro;
using UnityEngine;

[AddComponentMenu("Layout/TMP Container Size Fitter")]
public class TMPContainerSizeFitter : MonoBehaviour
{
    [SerializeField] private TMP_Text tmp;
    [SerializeField] private float widthBorder;
    [SerializeField] private float heightBorder;

    private RectTransform rectTransform;
    private RectTransform tmpRectTransform;
    private float preferredHeight;
    private float preferredWidth;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        tmpRectTransform = tmp.rectTransform;
    }

    void Start()
    {
        SetHeight();
        SetWidth();
    }

    void Update()
    {
        if (preferredHeight != tmp.preferredHeight)
            SetHeight();
        if (preferredWidth != tmp.preferredWidth)
            SetWidth();
    }

    void SetHeight()
    {
        if (tmp == null)
            return;

        preferredHeight = tmp.preferredHeight;
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, preferredHeight + heightBorder);
        tmpRectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, preferredHeight + heightBorder);

        SetDirty();
    }

    void SetWidth()
    {
        if (tmp == null)
            return;

        preferredWidth = tmp.preferredWidth;
        rectTransform.sizeDelta = new Vector2(preferredWidth + widthBorder, rectTransform.sizeDelta.y);
        tmpRectTransform.sizeDelta = new Vector2(preferredWidth + widthBorder, rectTransform.sizeDelta.y);

        SetDirty();
    }

    #region MarkLayoutForRebuild
    bool IsActive()
    {
        return isActiveAndEnabled;
    }

    void SetDirty()
    {
        if (!IsActive())
            return;

        UnityEngine.UI.LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }

    void OnRectTransformDimensionsChange()
    {
        SetDirty();
    }


#if UNITY_EDITOR
    void OnValidate()
    {
        SetDirty();
    }
#endif

    #endregion
}
