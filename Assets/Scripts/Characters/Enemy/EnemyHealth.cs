using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100;

    [SerializeField]
    private GameObject floatingTextPrefab;

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            Destroy (gameObject);
        }
        else
        {
            health -= damage;

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
