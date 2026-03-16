using UnityEngine;

public class BowAttack : MonoBehaviour
{
    public Weapon bow;
    public GameObject arrowPrefab;
    public float timer = 0f;

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
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        Projectile projectile = arrow.GetComponent<Projectile>();

        ProjectileData data = new ProjectileData();
        data.velocity = Vector2.right * bow.projectileSpeed;
        data.damage = bow.damage;
        data.piercesRemaining = 1;
        data.ownerTag = "Player";

        projectile.data = data;

        Destroy(arrow, 2f);
    }
}
