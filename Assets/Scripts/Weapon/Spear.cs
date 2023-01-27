using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private Animation anim;

    [SerializeField]
    private KnockBack knockBack;

    private EdgeCollider2D _edgeCollider2D;

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
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    private void Update()
    {
        if (anim.isPlaying)
        {
            _edgeCollider2D.enabled = true;
        }
        else
        {
            _edgeCollider2D.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);

            other.gameObject.GetComponent<EnemyAI>().canFindPlayer = false;

            //knock backing
            knockBack
                .Execute(other.gameObject.GetComponent<Rigidbody2D>(),
                transform.position,
                other.gameObject.transform.position);
        }
    }

        

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _edgeCollider2D.enabled = false;
            other.gameObject.GetComponent<EnemyAI>().canFindPlayer = true;
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
