using UnityEngine;

public class OrbitingShield : Ability
{
    public GameObject shieldPrefab;
    public Transform player;
    public float orbitRadius = 1.5f;
    public float orbitSpeed = 120f;
    public int shieldCount = 1;

    private GameObject[] shields;

    void Start()
    {
        abilityName = "Orbiting Shield";
        CreateShields();
    }

    protected override void Update()
    {
        base.Update();
        Activate();
    }

    public override void Activate()
    {
        if (shields == null) return;

        for (int i = 0; i < shields.Length; i++)
        {
            if (shields[i] == null) continue;

            float angle = Time.time * orbitSpeed + (360f / shields.Length) * i;
            float radians = angle * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), 0f) * orbitRadius;
            shields[i].transform.position = player.position + offset;
        }
    }

    public override void Upgrade()
    {
        level++;
        shieldCount++;
        orbitRadius += 0.2f;
        CreateShields();
    }

    void CreateShields()
    {
        if (shields != null)
        {
            for (int i = 0; i < shields.Length; i++)
            {
                if (shields[i] != null)
                    Destroy(shields[i]);
            }
        }

        shields = new GameObject[shieldCount];

        for (int i = 0; i < shieldCount; i++)
        {
            shields[i] = Instantiate(shieldPrefab, player.position, Quaternion.identity);
        }
    }
}
