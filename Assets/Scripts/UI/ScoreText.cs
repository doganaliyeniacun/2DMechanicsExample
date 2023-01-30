using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMesh;

    private float _count = 0;

    private void OnEnable()
    {
        Coin.OnCollected += IncrementCount;
    }

    private void OnDisable()
    {
        Coin.OnCollected -= IncrementCount;
    }

    private void Start()
    {
        _textMesh.text = "Score : " + _count;
    }

    private void IncrementCount()
    {
        _count++;

        _textMesh.text = "Score : " + _count;
    }
}
