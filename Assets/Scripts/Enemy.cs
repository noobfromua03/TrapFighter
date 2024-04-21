using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private NoteItem noteItemPrefab;

    private CharacterController character;
    private float speed = 1;
    private float hp = 25;

    private float attackSpeed = 1;
    private float attackTimer = 0;

    private Note note;

    public Action OnDie;

    private bool isFacingRight = true;

    private void Start()
    {
        character = FindObjectOfType<CharacterController>();
    }

    public void ChangeSpeed(float speed)
    {
        this.speed = speed;
    }

    public void ChangeHP(float hp)
    {
        this.hp = hp;
    }

    public void AddNote(Note note)
    {
        this.note = note;
    }

    private void FixedUpdate()
    {
        if (character == null)
            return;

        attackTimer += Time.deltaTime;

        var direction = character.transform.position - transform.position;
        rb.MovePosition(rb.position + (Vector2)direction * speed * Time.deltaTime);
        Flip(direction.x);

        if (Vector3.Distance(character.transform.position, transform.position) < 0.75f && attackTimer >= attackSpeed)
        {
            GetComponentInChildren<Animator>().SetTrigger("attack");
            character.TakeDamage(5);
            attackTimer = 0f;
        }
    }

    public void TakeDamage(float damage)
    {
        GetComponentInChildren<Animator>().SetTrigger("hurt");
        hp -= damage;
        if (hp <= 0)
        {
            OnDie?.Invoke();
            if (note != null)
            {
                var noteItem = Instantiate(noteItemPrefab, transform.position, Quaternion.identity);
                noteItem.Initialize(note);
            }
            Destroy(gameObject);
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
