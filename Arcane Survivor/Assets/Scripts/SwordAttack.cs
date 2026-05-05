using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Weapon sword;
    public Transform attackCenter;
    public GameObject swordAOE;
    public float aoeDisplayTime = 0.2f;

    public float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= sword.cooldown)
        {
            timer = 0f;
            Attack();
        }
    }

    void Attack()
    {
        ShowAOE();

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            attackCenter.position,
            sword.area
        );

        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(sword.damage);
            }
        }
    }

    void ShowAOE()
    {
        if (swordAOE == null) return;

        swordAOE.SetActive(true);
        swordAOE.transform.position = attackCenter.position;
        swordAOE.transform.localScale = Vector3.one * sword.area;

        CancelInvoke(nameof(HideAOE));
        Invoke(nameof(HideAOE), aoeDisplayTime);
    }

    void HideAOE()
    {
        swordAOE.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        if (sword == null || attackCenter == null) return;

        Gizmos.DrawWireSphere(attackCenter.position, sword.area);
    }
}