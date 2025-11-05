using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHealthBarValue (int setHealthBar)
    {
        slider.maxValue = setHealthBar;
        slider.value = setHealthBar;
    }

    public void setHealthBarValue (int setHealthBar)
    {
        slider.value = setHealthBar;
    }
}
