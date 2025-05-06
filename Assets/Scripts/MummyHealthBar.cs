using UnityEngine;
using UnityEngine.UI;

public class MummyHealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;

    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
    public void UpdateHealthBar(int health)
    {
        healthSlider.value = health;
    }
}
