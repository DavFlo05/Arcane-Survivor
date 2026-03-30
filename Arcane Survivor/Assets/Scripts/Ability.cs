using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public string abilityName;
    public int level = 1;
    public float cooldown = 1f;
    protected float cooldownTimer;

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public abstract void Activate();

    public abstract void Upgrade();
}