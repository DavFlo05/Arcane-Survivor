using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        float targetHealth = GameManager.instance.playerStats["Health"];

        slider.value = Mathf.Lerp(slider.value, targetHealth, Time.deltaTime * 5f);
    }
}