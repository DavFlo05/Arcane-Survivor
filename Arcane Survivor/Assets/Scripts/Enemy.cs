using UnityEngine;
public class Enemy : MonoBehaviour 
{ 
    public EnemyType type; 
    public float damage = 5f; 
    public Transform player; 
    
    void OnDestroy() 
    { if (GameManager.instance != null) 
        
        { 
            GameManager.instance.RemoveEnemy(this); 
        } 
    } 
}
public enum EnemyType { Melee, Fast, Tank }