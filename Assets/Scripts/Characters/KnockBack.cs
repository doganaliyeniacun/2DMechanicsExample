using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public bool KnockFromRight;

    public Vector2 KBForce = new Vector2(1f, 0);

    private Rigidbody2D _rb;
    private bool _canKnockBack = false;

    private void FixedUpdate()
    {        
        if (_canKnockBack)
        {
            if (KnockFromRight && _rb)
            {
                _rb.AddForce(new Vector2(-KBForce.x, KBForce.y),ForceMode2D.Impulse);
            }

            if (!KnockFromRight && _rb)
            {
                _rb.AddForce(new Vector2(KBForce.x, KBForce.y),ForceMode2D.Impulse);
            }

            _canKnockBack = false;
        }
    }

    public void Execute(Rigidbody2D rb,Vector2 localPos, Vector2 otherPos)
    {
        _rb = rb;
        _canKnockBack = true;

        if (localPos.x <= otherPos.x)
        {
            KnockFromRight = true;
        }

        if (localPos.x > otherPos.x)
        {
            KnockFromRight = false;
        }
    }
}
