using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Unity.VisualScripting;

public class Spear : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private Animation anim;

    private EdgeCollider2D edgeCollider2D;

    private void OnEnable()
    {
        PlayerManager.AttackEvents += Attack;
    }

    private void OnDisable()
    {
        PlayerManager.AttackEvents -= Attack;
    }

    private void Awake()
    {
        edgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    private void Update()
    {
        if (anim.isPlaying)
        {
            edgeCollider2D.enabled = true;
        }
        else
        {
            edgeCollider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    private void Attack()
    {
        if (anim)
        {
            anim.Play("NormalAttack");
        }
    }
}
