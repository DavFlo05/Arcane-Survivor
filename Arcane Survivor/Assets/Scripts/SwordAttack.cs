using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Weapon sword;
    public float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= sword.cooldown)
        {
            timer = 0f;
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, sword.area);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                Enemy enemy = hit.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(sword.damage);
                }
            }
        }
    }
}
