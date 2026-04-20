using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyDestroyed;

    public EnemyType type;
    public float damage = 5f;
    public Transform player;
    public float health = 20f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            OnEnemyDestroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}

public enum EnemyType { Melee, Fast, Tank }