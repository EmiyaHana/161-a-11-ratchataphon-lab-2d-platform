using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private int maxHealth;

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
    }

    public void SetHealth(int value)
    {
        float ratio = (float)value / maxHealth;
        fillImage.fillAmount = ratio;

        fillImage.color = Color.Lerp(Color.red, Color.green, ratio);
    }
}