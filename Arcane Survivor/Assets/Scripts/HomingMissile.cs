using UnityEngine;
using System.Collections.Generic;

public class HomingMissile : Ability
{
    public GameObject missilePrefab;
    public Transform player;
    public float range = 10f;

    void Start()
    {
        abilityName = "Homing Missile";
        cooldown = 2f;
    }

    protected override void Update()
    {
        base.Update();

        if (cooldownTimer <= 0f)
        {
            Activate();
            cooldownTimer = cooldown;
        }
    }

    public override void Activate()
    {
        Enemy target = FindClosestEnemy();

        if (target == null) return;

        GameObject missile = Instantiate(missilePrefab, player.position, Quaternion.identity);
        HomingProjectile projectile = missile.GetComponent<HomingProjectile>();

        if (projectile != null)
        {
            projectile.target = target.transform;
            projectile.damage = 10f + (level * 5f);
        }
    }

    public override void Upgrade()
    {
        level++;
        cooldown = Mathf.Max(0.5f, cooldown - 0.2f);
    }

    Enemy FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);

        Enemy closest = null;
        float closestDistance = range;

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector2.Distance(player.position, enemy.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy;
            }
        }

        return closest;
    }
}
