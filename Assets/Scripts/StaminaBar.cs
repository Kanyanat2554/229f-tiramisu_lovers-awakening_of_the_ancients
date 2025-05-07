using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaSlider;

    public void SetMaxStamina(float max)
    {
        staminaSlider.maxValue = max;
    }

    public void SetStamina(float value)
    {
        staminaSlider.value = value;
    }
}
