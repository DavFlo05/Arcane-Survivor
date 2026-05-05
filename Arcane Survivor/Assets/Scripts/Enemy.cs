using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDestroyed;

    public EnemyType type;
    public float damage = 5f;
    public Transform player;
    public float health = 20f;
    public int expValue = 5;
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            PlayerLevel playerLevel = FindFirstObjectByType<PlayerLevel>();

            if (playerLevel != null)
            {
                playerLevel.GainExp(expValue);
            }

            OnEnemyDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

public enum EnemyType { Melee, Fast, Tank }