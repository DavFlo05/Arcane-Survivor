using UnityEngine;

public class ExplosiveAura : Ability
{
    public Transform player;
    public float radius = 2f;
    public float baseDamage = 15f;
    public GameManager gameManager;

    void Start()
    {
        abilityName = "Explosive Aura";
        cooldown = 3f;
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
        float damageStat = gameManager.playerStats["Damage"];

        ModifyDamageWithAura(ref damageStat);

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

    public override void Upgrade()
    {
        level++;
        radius += 0.3f;
        baseDamage += 5f;
    }

    void ModifyDamageWithAura(ref float damageValue)
    {
        damageValue += level * 2f;
    }
}