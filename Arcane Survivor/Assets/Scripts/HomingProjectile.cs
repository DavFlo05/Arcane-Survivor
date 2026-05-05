using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public Transform target;
    public float speed = 8f;
    public float damage = 10f;

    public float explosionDelay = 1.5f;
    public float explosionRadius = 2f;

    public GameObject explosionZoneVisual;

    private bool stuck = false;
    private Enemy stuckEnemy;

    void Update()
    {
        if (stuck) return;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (stuck) return;

        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            stuck = true;
            stuckEnemy = enemy;

            transform.SetParent(enemy.transform);
            transform.localPosition = Vector3.zero;

            if (explosionZoneVisual != null)
            {
                explosionZoneVisual.SetActive(true);
                explosionZoneVisual.transform.localScale = Vector3.one * explosionRadius * 2f;
            }

            Invoke(nameof(Explode), explosionDelay);
        }
    }

    void Explode()
    {
        transform.SetParent(null);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}