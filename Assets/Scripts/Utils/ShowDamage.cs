using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject floatingTextPrefab;

    public void Execute(float damage)
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
