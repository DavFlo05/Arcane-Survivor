using UnityEngine;

public class BowAttack : MonoBehaviour
{
    public Weapon bow;
    public GameObject arrowPrefab;
    public float timer = 0f;
    public float aimRange = 12f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= bow.cooldown)
        {
            timer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        Enemy target = FindClosestEnemy();

        if (target == null) return;

        Vector2 direction = (target.transform.position - transform.position).normalized;

        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        Projectile projectile = arrow.GetComponent<Projectile>();

        ProjectileData data = new ProjectileData();
        data.velocity = direction * bow.projectileSpeed;
        data.damage = bow.damage;
        data.piercesRemaining = 1;
        data.ownerTag = "Player";

        projectile.data = data;

        Destroy(arrow, 2f);
    }

    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        Enemy closest = null;
        float closestDistance = aimRange;

        Camera cam = Camera.main;

        foreach (Enemy enemy in enemies)
        {
            Vector3 screenPoint = cam.WorldToViewportPoint(enemy.transform.position);

            bool enemyIsVisible =
                screenPoint.z > 0 &&
                screenPoint.x >= 0 && screenPoint.x <= 1 &&
                screenPoint.y >= 0 && screenPoint.y <= 1;

            if (!enemyIsVisible)
            {
                continue;
            }

            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}
