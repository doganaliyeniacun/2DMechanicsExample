using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public bool KnockFromRight;

    public Vector2 KBForce = new Vector2(1f, 0);

    private Rigidbody2D _rb;

    private bool _canKnockBack = false;

    private void FixedUpdate()
    {
        KnockBacking();
    }

    /// <summary>
    /// Belirlenen hedefe ters yönde kuvvet uygular.
    ///</summary>
    ///<param name = "rb"> Kuveet uygulanacak objenin RigidBody2D compenentini alır</param>
    ///<param name = "localPos"> Yön için, kuvveti uygulayacak olan objenin lokal pozisyonunu alır </param>
    ///<param name = "targetPos"> Yön için, kuvvet uygulanacak objenin pozisyonunu alır </param>
    public void Execute(Rigidbody2D rb, Vector2 localPos, Vector2 targetPos)
    {
        _rb = rb;
        _canKnockBack = true;

        if (targetPos.x <= localPos.x)
        {
            KnockFromRight = true;
        }

        if (targetPos.x > localPos.x)
        {
            KnockFromRight = false;
        }
    }

    private void KnockBacking()
    {
        if (_canKnockBack)
        {
            if (KnockFromRight && _rb)
            {
                _rb
                    .AddForce(new Vector2(-KBForce.x, KBForce.y),
                    ForceMode2D.Impulse);
            }

            if (!KnockFromRight && _rb)
            {
                _rb
                    .AddForce(new Vector2(KBForce.x, KBForce.y),
                    ForceMode2D.Impulse);
            }

            _canKnockBack = false;
        }
    }
}
