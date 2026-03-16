using UnityEngine;
public class Enemy : MonoBehaviour 
{ 
    public EnemyType type; 
    public float damage = 5f; 
    public Transform player; 
    public float health = 20f;
    void OnDestroy() 
    { if (GameManager.instance != null) 
        
        { 
            GameManager.instance.RemoveEnemy(this); 
        } 
    }
    

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
public enum EnemyType { Melee, Fast, Tank }