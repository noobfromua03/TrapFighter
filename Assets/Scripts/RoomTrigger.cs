using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public BoolUnityEvent OnEnter;
    public bool isFirst;

    [System.Serializable]
    public class BoolUnityEvent : UnityEngine.Events.UnityEvent<bool> { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterController ch))
            OnEnter?.Invoke(isFirst);
    }
}
