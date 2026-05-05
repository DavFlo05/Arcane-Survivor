using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public GameObject swordObject;
    public GameObject bowObject;
    public GameObject axeObject;

    public BowAttack bowAttack;
    public AxeAttack axeAttack;

    public GameObject weaponSelectPanel;

    void Start()
    {
        Time.timeScale = 0f;

        GameManager.instance.canSpawnEnemies = false;

        swordObject.SetActive(false);
        bowObject.SetActive(false);
        axeObject.SetActive(false);

        bowAttack.enabled = false;
        axeAttack.enabled = false;

        weaponSelectPanel.SetActive(true);
    }

    public void SelectSword()
    {
        swordObject.SetActive(true);
        bowObject.SetActive(false);
        axeObject.SetActive(false);

        bowAttack.enabled = false;
        axeAttack.enabled = false;

        StartGame();
    }

    public void SelectBow()
    {
        swordObject.SetActive(false);
        bowObject.SetActive(true);
        axeObject.SetActive(false);

        bowAttack.enabled = true;
        axeAttack.enabled = false;

        StartGame();
    }

    public void SelectAxe()
    {
        swordObject.SetActive(false);
        bowObject.SetActive(false);
        axeObject.SetActive(true);

        bowAttack.enabled = false;
        axeAttack.enabled = true;

        StartGame();
    }

    void StartGame()
    {
        weaponSelectPanel.SetActive(false);
        Time.timeScale = 1f;

        GameManager.instance.StartEnemySpawning(); // ✅ THIS replaces enemySpawner
    }
}