using UnityEngine;
using Unity.Mathematics;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float _health = 100f;

    private float _currentHealth;

    [SerializeField]
    private GameObject floatingTextPrefab;

    [SerializeField]
    private HealthBar _healthBar;

    private void Awake()
    {
        _currentHealth = _health;
    }

    private void Start()
    {
        _healthBar.UpdateHealthBar (_health, _currentHealth);        
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0)
        {
            Destroy (gameObject);
        }
        else
        {
            _currentHealth -= damage;
            _healthBar.UpdateHealthBar (_health, _currentHealth);

            ShowDamage (damage);
        }
    }

    private void ShowDamage(float damage)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab =
                Instantiate(floatingTextPrefab,
                new Vector2(transform.position.x, transform.position.y),
                Quaternion.identity);

            prefab
                .GetComponentInChildren<FloatingTextController>()
                .Execute(damage.ToString());
        }
    }
}
