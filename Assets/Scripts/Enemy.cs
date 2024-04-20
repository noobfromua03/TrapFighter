using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody2D rb;

    private CharacterController character;
    private float speed = 1;
    private float hp = 25;

    private float attackSpeed = 1;
    private float attackTimer = 0;

    public Action OnDie;

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

    private void Update()
    {
        if (character == null)
            return;

        attackTimer += Time.deltaTime;

        var direction = character.transform.position - transform.position;
        rb.MovePosition(rb.position + (Vector2)direction * speed * Time.deltaTime);

        if(Vector3.Distance(character.transform.position, transform.position) < 0.75f && attackTimer >= attackSpeed)
        {
            character.TakeDamage(5);
            attackTimer = 0f;
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
