using UnityEngine;
using UnityEngine.InputSystem;

public class ExampleLevelUpTester : MonoBehaviour
{
    public AbilityManager abilityManager;

    void Update()
    {
        if (Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            abilityManager.TryUpgradeAbility(0, out bool valid, out string message);
            Debug.Log(message);
        }

        if (Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            abilityManager.TryUpgradeAbility(1, out bool valid, out string message);
            Debug.Log(message);
        }

        if (Keyboard.current.numpad3Key.wasPressedThisFrame)
        {
            abilityManager.TryUpgradeAbility(2, out bool valid, out string message);
            Debug.Log(message);
        }
    }
}
