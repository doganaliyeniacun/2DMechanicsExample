using UnityEngine;

public abstract class HealthBase : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100f;
    private float _currentHealth;
    public float MaxHealth { get => _maxHealth;}
    public float CurrentHealth { get => _currentHealth; set => _currentHealth = value; }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
}
