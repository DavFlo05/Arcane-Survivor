using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject settingsPanel;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // shows in editor

        Application.Quit();
    }
}
