using UnityEngine;

public class OrbitingShield : Ability
{
    public GameObject shieldPrefab;
    public Transform player;

    GameObject currentShield;

    public override void Activate()
    {
        if (currentShield == null)
        {
            currentShield = Instantiate(shieldPrefab, player.position, Quaternion.identity);

            OrbitingShieldObject shield = currentShield.GetComponent<OrbitingShieldObject>();
            shield.player = player;
        }
    }

    public override void Upgrade()
    {
        level++;

        if (currentShield != null)
        {
            OrbitingShieldObject shield = currentShield.GetComponent<OrbitingShieldObject>();

            shield.damage += 5f;
            shield.radius += 0.2f;
            shield.speed += 20f;
        }
    }

    void Start()
    {
        abilityName = "Orbiting Shield";
        Activate();
    }
}