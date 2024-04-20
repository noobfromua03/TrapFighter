using FVN.WindowSystem;
using UnityEngine;

public class NoteItem : MonoBehaviour
{
    private Note note;

    public void Initialize(Note note)
    {
        this.note = note;
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Windows.OkWindow($"�������� {note.princessId}", note.text, "����������");
        GameController.Instance.AddNote(note);
        Destroy(gameObject);
    }
}

[System.Serializable]
public class Note
{
    public int princessId;
    public string text;
}
