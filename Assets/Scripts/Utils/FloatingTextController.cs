using TMPro;
using UnityEngine;


public class FloatingTextController : MonoBehaviour
{
    private Animation anim;

    private TextMesh textMesh;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        textMesh = GetComponent<TextMesh>();
    }

    public  void Execute(string text)
    {
        if (textMesh)
        {
            textMesh.text = text;
            anim.Play("FloatingText");
        }
    }

  
}
