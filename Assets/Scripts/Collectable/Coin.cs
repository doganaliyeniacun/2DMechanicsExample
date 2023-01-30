using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static event Action OnCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy (gameObject);
            OnCollected?.Invoke();
        }
    }
}
