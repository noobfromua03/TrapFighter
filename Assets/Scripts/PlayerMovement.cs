using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public Rigidbody2D rb;

    public bool CanMove = true;

    private bool isFacingRight = false;

    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }

    private void Update()
    {
        if (CanMove == false)
            return;

        var vector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        rb.MovePosition(transform.position + vector * speed * Time.deltaTime);
        Flip(vector.x);
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
