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

    private List<Note> notes;

    public void Initialize(List<Note> notes)
    {
        this.notes = notes;
    }

    public void OnClick(int index)
    {
        foreach (Transform child in factsContainer)
            Destroy(child.gameObject);

        if (notes.Count > 0)
        {
            canvasFacts.SetActive(true);
            foreach (var note in notes.Where(n => n.princessId == index))
            {
                var fact = Instantiate(factPrefab, factsContainer);
                fact.GetComponentInChildren<TMP_Text>().text = note.text;
            }
        }
    }

    public void CloseFacts()
    {
        canvasFacts.SetActive(false);
    }
}
