using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public string enemyName;
    public int hp;
    public float speed;
}

[System.Serializable]
[XmlRoot("EnemyDatabase")]
public class EnemyDatabase
{
    [XmlElement("Enemy")]
    public List<EnemyData> enemies = new List<EnemyData>();
}

public class EnemyDataLoader : MonoBehaviour
{
    public List<EnemyData> loadedEnemies = new List<EnemyData>();
    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, "EnemyData.xml");
        LoadEnemyData();
    }

    void LoadEnemyData()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogWarning("Enemy XML file not found: " + filePath);
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(EnemyDatabase));

        using (FileStream stream = new FileStream(filePath, FileMode.Open))
        {
            EnemyDatabase database = serializer.Deserialize(stream) as EnemyDatabase;
            loadedEnemies = database.enemies;
        }

        Debug.Log("Loaded " + loadedEnemies.Count + " enemies from XML.");
    }
}