using UnityEngine;
using UnityEngine.Events;

public class FinishLevelTrigger : MonoBehaviour
{
    public UnityEvent OnFinish;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger finish");
        if (collision.TryGetComponent(out CharacterController ch))
        {
            Debug.Log("Finish by player");
            OnFinish?.Invoke();
        }
    }
}
