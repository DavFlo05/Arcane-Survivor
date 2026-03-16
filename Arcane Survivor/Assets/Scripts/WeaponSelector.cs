using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSelector : MonoBehaviour
{
    public GameObject swordObject;
    public GameObject bowObject;

    public SwordAttack swordAttack;
    public BowAttack bowAttack;

    void Start()
    {
        swordObject.SetActive(false);
        bowObject.SetActive(false);

        swordAttack.enabled = false;
        bowAttack.enabled = false;
    }

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            SelectSword();
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            SelectBow();
        }
    }

    void SelectSword()
    {
        swordObject.SetActive(true);
        bowObject.SetActive(false);

        swordAttack.enabled = true;
        bowAttack.enabled = false;
    }

    void SelectBow()
    {
        swordObject.SetActive(false);
        bowObject.SetActive(true);

        swordAttack.enabled = false;
        bowAttack.enabled = true;
    }
}