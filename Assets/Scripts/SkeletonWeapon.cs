using UnityEngine;

public class SkeletonWeapon : MonoBehaviour
{
    private bool initialized = false;

    private SkeletonData data;

    private int damage = 20;

    public void Initialize(SkeletonData data)
    {
        this.data = data;
        initialized = true;
    }

    void Update()
    {
        if (!initialized)
            return;

        transform.Rotate(Vector3.forward * data.attackSpeedMultiplier * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!initialized)
            return;

        if (collision.TryGetComponent(out IDamageable damageable))
            damageable.TakeDamage(data.damageMultiplier * damage);
    }
}
