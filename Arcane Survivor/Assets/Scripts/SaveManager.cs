using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public int playerCoins = 0;
    public int playerHealth = 100;
    public int currentLevel = 1;

    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveData.json");
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData data = new SaveData();
        data.playerCoins = playerCoins;
        data.playerHealth = playerHealth;
        data.currentLevel = currentLevel;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);

        Debug.Log("Game saved to: " + savePath);
    }

    public void LoadGame()
    {
        if (!File.Exists(savePath))
        {
            Debug.Log("No save file found. Starting with default values.");
            return;
        }

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        playerCoins = data.playerCoins;
        playerHealth = data.playerHealth;
        currentLevel = data.currentLevel;

        Debug.Log("Game loaded from: " + savePath);
    }
}