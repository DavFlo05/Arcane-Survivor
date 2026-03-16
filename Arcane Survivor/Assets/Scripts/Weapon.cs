using UnityEngine;


public class Weapon : MonoBehaviour
{
    public float damage = 10f;
    public float cooldown = 1f;
    public float projectileSpeed = 5f;
    public float area = 1.5f;

    public AbilityType abilityType;
    public WeaponTier weaponTier;
    void Start()
    {
        switch (weaponTier)
        {
            case WeaponTier.Common:
                damage += 0;
                break;

            case WeaponTier.Rare:
                damage += 5;
                break;

            case WeaponTier.Epic:
                damage += 10;
                break;

            case WeaponTier.Legendary:
                damage += 15;
                break;
        }
    }
}

public enum AbilityType
{
    Projectile,
    Aura,
    Melee,
    Nova
}

public enum WeaponTier
{
    Common,
    Rare,
    Epic,
    Legendary
}
