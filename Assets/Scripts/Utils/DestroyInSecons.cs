using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSecons : MonoBehaviour
{
    [SerializeField]
    private float secondsToDestroy = 3f;

    private void Start()
    {
        Destroy (gameObject, secondsToDestroy);
    }
}
