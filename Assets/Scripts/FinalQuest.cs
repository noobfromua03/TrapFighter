using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FinalQuest : MonoBehaviour
{
    [SerializeField] private GameObject canvasFacts;
    [SerializeField] private Transform factsContainer;
    [SerializeField] private GameObject factPrefab;
    [SerializeField] private TMP_Text label;
    [SerializeField] private List<Transform> screens;

    private List<Note> notes;

    private bool finished = false;

    public void Initialize(List<Note> notes)
    {
        this.notes = notes;
    }

    public void OnClick(int index)
    {
        foreach (Transform child in factsContainer)
            Destroy(child.gameObject);

        label.text = $"�������� {index + 1}";
        canvasFacts.SetActive(true);
        if (notes.Count > 0)
        {
            foreach (var note in notes.Where(n => n.princessId == index))
            {
                var fact = Instantiate(factPrefab, factsContainer);
                fact.GetComponentInChildren<TMP_Text>().text = note.text;
            }
        }
        else
        {
            var fact = Instantiate(factPrefab, factsContainer);
            fact.GetComponentInChildren<TMP_Text>().text = "�� �������� ������ �������.";
        }
    }

    public void CloseFacts()
    {
        canvasFacts.SetActive(false);
    }

    public void Pickup(int index)
    {
        if (finished)
            return;

        finished = true;
        StartCoroutine(ScreenAnim(screens[index]));
    }


    private IEnumerator ScreenAnim(Transform tr)
    {
        for(float i = 0f; i <= 50f; i += Time.deltaTime * 5f)
        {
            tr.Translate(Vector3.up * i);
            yield return null;
        }
    }
}
