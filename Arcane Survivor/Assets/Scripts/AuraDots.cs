using UnityEngine;

public class AuraDotsVisual : MonoBehaviour
{
    public ExplosiveAura explosiveAura;
    public GameObject dotPrefab;

    public int dotCount = 40;
    public float dotSize = 0.08f;

    void Start()
    {
        CreateDots();
    }

    public void CreateDots()
    {
        if (explosiveAura == null || dotPrefab == null) return;

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < dotCount; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * explosiveAura.radius;

            GameObject dot = Instantiate(dotPrefab, transform);
            dot.transform.localPosition = randomPoint;
            dot.transform.localScale = Vector3.one * dotSize;
        }
    }

    void Update()
    {
        if (explosiveAura != null && explosiveAura.player != null)
        {
            transform.position = explosiveAura.player.position;
        }
    }
}
