using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData data;

    void Update()
    {
        transform.position += (Vector3)(data.velocity * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(data.damage);
            }

            data.piercesRemaining--;

            if (data.piercesRemaining <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
