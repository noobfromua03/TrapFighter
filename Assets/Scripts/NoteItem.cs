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
        Destroy(gameObject);
    }
}

public class Note
{
    public int princessId;
    public string text;
}
