using UnityEngine;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public GameObject levelUpPanel;

    public Button option1Button;
    public Button option2Button;
    public Button option3Button;

    public AbilityManager abilityManager;

    void Start()
    {
        levelUpPanel.SetActive(false);
    }

    public void ShowLevelUpChoices()
    {
        levelUpPanel.SetActive(true);

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();
        option3Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(() => ChooseUpgrade(0));
        option2Button.onClick.AddListener(() => ChooseUpgrade(1));
        option3Button.onClick.AddListener(() => ChooseUpgrade(2));
    }

    void ChooseUpgrade(int abilityIndex)
    {
        abilityManager.TryUpgradeAbility(abilityIndex, out bool valid, out string message);

        Debug.Log(message);

        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
