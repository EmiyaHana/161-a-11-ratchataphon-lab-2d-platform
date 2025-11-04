using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    private int maxHealth = 100;

    public void SetMaxHealth(int value)
    {
        maxHealth = Mathf.Max(1, value);
        SetHealth(value);
    }

    public void SetHealth(int value)
    {
        if (fillImage == null)
        {
            Debug.LogError("Fill Image not assigned in HealthBar!");
            return;
        }

        float ratio = Mathf.Clamp01((float)value / maxHealth);
        fillImage.fillAmount = ratio;
        fillImage.color = Color.Lerp(Color.red, Color.green, ratio);
    }
}