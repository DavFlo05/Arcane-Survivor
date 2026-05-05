using UnityEngine;

public class AxeProjectile : MonoBehaviour
{
    public float speed = 8f;
    public float damage = 10f;
    public int maxBounces = 3;
    public float bounceRadius = 6f;
    public float lifetime = 4f;

    private int currentBounces = 0;
    private Transform currentTarget;
    private Vector2 moveDirection;

    void Start()
    {
        moveDirection = transform.right; // ✅ uses rotation from AxeAttack
    }

    void Update()
    {
        transform.Rotate(0f, 0f, 720f * Time.deltaTime);

        if (currentTarget != null)
        {
            moveDirection = (currentTarget.position - transform.position).normalized;
        }

        transform.position += (Vector3)(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Enemy")) return;

        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        if (currentBounces < maxBounces)
        {
            Transform next = FindNextTarget(other.transform);

            if (next != null)
            {
                currentTarget = next;
                currentBounces++;
                return;
            }
        }

        Destroy(gameObject);
    }

    Transform FindNextTarget(Transform ignore)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, bounceRadius);

        float closest = Mathf.Infinity;
        Transform best = null;

        foreach (Collider2D col in hits)
        {
            if (!col.CompareTag("Enemy")) continue;
            if (col.transform == ignore) continue;

            float dist = Vector2.Distance(transform.position, col.transform.position);

            if (dist < closest)
            {
                closest = dist;
                best = col.transform;
            }
        }

        return best;
    }
}