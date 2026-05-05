using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;

    public GameObject meleeEnemyPrefab;
    public GameObject fastEnemyPrefab;
    public GameObject tankEnemyPrefab;

    public GameOverUI gameOverUI;

    public List<Enemy> activeEnemies = new List<Enemy>();
    public Dictionary<string, float> playerStats = new Dictionary<string, float>();

    public bool canSpawnEnemies = false;

    float spawnTimer = 0f;
    public float spawnInterval = 1.5f;

    public int enemiesPerSpawn = 3;
    public int maxEnemies = 80;

    float difficultyTimer = 0f;
    public float difficultyInterval = 15f;

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        Enemy.OnEnemyDestroyed += RemoveEnemy;
    }

    void OnDisable()
    {
        Enemy.OnEnemyDestroyed -= RemoveEnemy;
    }

    void Start()
    {
        Time.timeScale = 1f;

        canSpawnEnemies = false;

        playerStats["Health"] = 100f;
        playerStats["Speed"] = 7f;
        playerStats["Damage"] = 10f;
    }

    void Update()
    {
        if (canSpawnEnemies)
        {
            SpawnLoop();
            HandleDifficulty();
        }

        CheckPlayerDamage();
    }

    void SpawnLoop()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            if (activeEnemies.Count >= maxEnemies) return;

            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (activeEnemies.Count < maxEnemies)
                {
                    SpawnEnemy();
                }
            }
        }
    }

    void HandleDifficulty()
    {
        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyInterval)
        {
            difficultyTimer = 0f;

            enemiesPerSpawn += 2;
            maxEnemies += 15;

            Debug.Log("Difficulty increased. Enemies per spawn: " + enemiesPerSpawn);
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = GetSpawnPositionAroundPlayer();

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
        ai.player = player;

        activeEnemies.Add(enemy);
    }

    Vector2 GetSpawnPositionAroundPlayer()
    {
        float spawnDistance = 10f;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        return (Vector2)player.position + randomDirection * spawnDistance;
    }

    void CheckPlayerDamage()
    {
        if (!canSpawnEnemies) return;

        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = activeEnemies[i];

            if (enemy == null)
            {
                activeEnemies.RemoveAt(i);
                continue;
            }

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

        if (gameOverUI != null)
            gameOverUI.ShowGameOver();
        else
            Time.timeScale = 0f;
    }

    public void StartEnemySpawning()
    {
        canSpawnEnemies = true;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
    }
}