using UnityEngine;

public class PlayerHealth : HealthBase, IHealth
{
    [SerializeField]
    private HealthBar _healthBar;

    private void Start()
    {
        _healthBar.UpdateHealthBar (MaxHealth, CurrentHealth);
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth <= 0)
        {
            Destroy (gameObject);
        }
        else
        {
            CurrentHealth -= damage;
            _healthBar.UpdateHealthBar (MaxHealth, CurrentHealth);
        }
    }
}
