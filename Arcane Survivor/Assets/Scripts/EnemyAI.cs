using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Enemy enemy;
    public Transform player;
    Rigidbody2D rb;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        switch (enemy.type)
        {
            case EnemyType.Melee:
                MoveTowardPlayer(2f);
                break;

            case EnemyType.Fast:
                MoveTowardPlayer(4f);
                break;

            case EnemyType.Tank:
                MoveTowardPlayer(1f);
                break;
        }
    }

    void MoveTowardPlayer(float speed)
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}