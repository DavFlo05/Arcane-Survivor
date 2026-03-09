using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;

    public GameObject meleeEnemyPrefab;
    public GameObject fastEnemyPrefab;
    public GameObject tankEnemyPrefab;

    public List<Enemy> activeEnemies = new List<Enemy>();

    public Dictionary<string, float> playerStats = new Dictionary<string, float>();

    float spawnTimer = 0f;
    int enemiesPerSpawn = 1;

    // map boundaries
    float mapMinX = -8f;
    float mapMaxX = 8f;
    float mapMinY = -6.3f;
    float mapMaxY = 6.3f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerStats["Health"] = 100f;
        playerStats["Speed"] = 7f;
        playerStats["Damage"] = 10f;
    }

    void Update()
    {
        SpawnLoop();
        CheckPlayerDamage();
    }

    void SpawnLoop()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 10f)
        {
            spawnTimer = 0f;

            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                SpawnEnemy();
            }

            enemiesPerSpawn++;

            Debug.Log("Enemies spawning: " + enemiesPerSpawn);
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomOffset = Random.insideUnitCircle * 4f;
        Vector2 spawnPos = (Vector2)player.position + randomOffset;

        // keep inside map
        spawnPos.x = Mathf.Clamp(spawnPos.x, mapMinX, mapMaxX);
        spawnPos.y = Mathf.Clamp(spawnPos.y, mapMinY, mapMaxY);

        int enemyType = Random.Range(0, 3);

        GameObject enemyObj = null;

        if (enemyType == 0)
            enemyObj = Instantiate(meleeEnemyPrefab, spawnPos, Quaternion.identity);

        if (enemyType == 1)
            enemyObj = Instantiate(fastEnemyPrefab, spawnPos, Quaternion.identity);

        if (enemyType == 2)
            enemyObj = Instantiate(tankEnemyPrefab, spawnPos, Quaternion.identity);

        Enemy enemy = enemyObj.GetComponent<Enemy>();
        EnemyAI ai = enemyObj.GetComponent<EnemyAI>();

        enemy.player = player;
        enemy.type = (EnemyType)enemyType;

        ai.player = player;   // THIS IS THE FIX

        activeEnemies.Add(enemy);
    }

    void CheckPlayerDamage()
    {
        foreach (Enemy enemy in activeEnemies)
        {
            if (enemy == null) continue;

            if (Vector2.Distance(player.position, enemy.transform.position) < 1.2f)
            {
                TakeDamage(enemy.damage * Time.deltaTime);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        playerStats["Health"] -= amount;

        if (playerStats["Health"] <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
    }
}