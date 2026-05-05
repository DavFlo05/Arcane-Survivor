using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 10;

    public LevelUpUI levelUpUI;

    public void GainExp(int amount)
    {
        currentExp += amount;

        if (currentExp >= expToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        currentExp -= expToNextLevel;
        level++;

        expToNextLevel += 10;

        Time.timeScale = 0f;

        levelUpUI.ShowLevelUpChoices();
    }
}