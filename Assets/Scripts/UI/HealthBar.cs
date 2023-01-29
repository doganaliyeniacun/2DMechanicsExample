using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _healthbarSprite;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        if (maxHealth == currentHealth)
        {
            gameObject.SetActive(false);
        }else
        {
            gameObject.SetActive(true);
        }
        
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
}
