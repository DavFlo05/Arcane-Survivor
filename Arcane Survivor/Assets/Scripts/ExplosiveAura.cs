using UnityEngine;

public class ExplosiveAura : Ability
{
    public Transform player;
    public float radius = 2f;
    public float baseDamage = 10f;
    public GameManager gameManager;

    public override void Activate()
    {
        try
        {
            float damageStat = gameManager.playerStats["Damage"];
            ModifyDamage(ref damageStat);

            Collider2D[] hits = Physics2D.OverlapCircleAll(player.position, radius);

            foreach (Collider2D hit in hits)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(baseDamage + damageStat);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("ExplosiveAura failed: " + ex.Message);
        }
    }

    public override void Upgrade()
    {
        level++;
        baseDamage += 5f;
        radius += 0.2f;
    }

    void ModifyDamage(ref float damageValue)
    {
        damageValue += level * 2f;
    }
}