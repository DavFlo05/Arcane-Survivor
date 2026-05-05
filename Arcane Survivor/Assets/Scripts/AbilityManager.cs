using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    public bool TryUpgradeAbility(int abilityIndex, out bool valid, out string message)
    {
        if (abilityIndex < 0 || abilityIndex >= abilities.Count)
        {
            valid = false;
            message = "Invalid ability choice.";
            return false;
        }

        Ability ability = abilities[abilityIndex];

        if (ability == null)
        {
            valid = false;
            message = "Ability slot is empty.";
            return false;
        }

        if (!ability.enabled)
        {
            ability.enabled = true;
            valid = true;
            message = ability.abilityName + " unlocked!";
            return true;
        }

        ability.Upgrade();

        valid = true;
        message = ability.abilityName + " upgraded to level " + ability.level;
        return true;
    }
}