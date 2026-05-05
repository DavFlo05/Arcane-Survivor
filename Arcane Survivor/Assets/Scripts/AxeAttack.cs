using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public GameObject axePrefab;
    public Transform firePoint;

    public float cooldown = 1.5f;
    public float angleStep = 45f; // 8 directions (12, 1:30, 3, etc)

    private float timer;
    private float currentAngle = 90f; // ✅ START at 12 o'clock

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ThrowAxe();
            timer = cooldown;
        }
    }

    void ThrowAxe()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, currentAngle);
        Instantiate(axePrefab, firePoint.position, rotation);

        // ✅ go clockwise
        currentAngle -= angleStep;

        // keep it between 0–360
        if (currentAngle < 0f)
            currentAngle += 360f;
    }
}
