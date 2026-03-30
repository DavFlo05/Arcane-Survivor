using UnityEngine;
using System.Collections.Generic;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();
    public int playerLevel = 1;

    public void TryUpgradeAbility(int index, out bool valid, out string message)
    {
        valid = false;
        message = "";

        if (abilities.Count == 0)
        {
            message = "No abilities are equipped.";
            return;
        }

        if (index < 0 || index >= abilities.Count)
        {
            message = "That upgrade choice is out of range.";
            return;
        }

        Ability chosenAbility = abilities[index];

        if (chosenAbility.level >= 5)
        {
            message = chosenAbility.abilityName + " is already max level.";
            return;
        }

        chosenAbility.Upgrade();
        valid = true;
        message = chosenAbility.abilityName + " upgraded to level " + chosenAbility.level + ".";
    }
}
