using UnityEngine;

public class OrbitingShieldObject : MonoBehaviour
{
    public Transform player;
    public float radius = 2f;
    public float speed = 100f;
    public float damage = 10f;

    float angle;

    void Update()
    {
        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        transform.position = player.position + new Vector3(x, y, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}