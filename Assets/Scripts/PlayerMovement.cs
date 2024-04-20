using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public Rigidbody2D rb;

    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        var vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        rb.MovePosition(transform.position + vector * speed * Time.deltaTime);

        var head = HeadConfig.Instance;
        var arm1 = RightArmConfig.Instance;
        var arm2 = LeftArmConfig.Instance;
        var leg1 = RightLegConfig.Instance;
        var leg2 = LeftLegConfig.Instance;
    }
}
