using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayerMask;

    [SerializeField]
    private float

            _radius = 5f,
            _moveSpeed = 5f,
            _damage = 10f,
            attackCooldown = 1f;

    private Rigidbody2D rb;

    private Vector2 playerPos;

    private float _attackCooldownLeft;

    public bool canFindPlayer = true;

    private bool _canAttack = false;

    private GameObject _player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canFindPlayer)
        {
            FindPlayer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CanAttack (_damage, _player);
        ChangeScale(playerPos - (Vector2) transform.position);
    }

    private void FindPlayer()
    {
        Collider2D player =
            Physics2D
                .OverlapCircle(transform.position, _radius, playerLayerMask);

        Vector2 currentDown = Vector2.down * 10;

        if (player != null)
        {
            playerPos = player.gameObject.transform.position;

            rb.velocity =
                new Vector2(playerPos.x - transform.position.x, currentDown.y);
        }
        else
        {
            rb.velocity = currentDown;
        }
    }

    /// <summary>
    /// Objenin yönünü sağ sol olacak şekilde belirtilen pozisyona göre değiştirir.
    ///</summary>
    ///<param name ="direction"> Bulunduğu konuma dönülecek karakterin konumu - bu objenin pozisyonunu alabilir  </param>
    private void ChangeScale(Vector2 direction)
    {
        Vector2 scale = transform.localScale;

        if (direction.x < 0)
        {
            scale.x = -1;
        }
        else if (direction.x > 0)
        {
            scale.x = 1;
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player = other.gameObject;
            _canAttack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _canAttack = false;
    }

    /// <summary>
    /// Player nesnesinin can değerini azaltır.
    ///</summary>
    ///<param name ="damage"> Saldırı gücünü alır </param>
    ///<param name ="player"> Player game objectini alır. </param>
    private void CanAttack(float damage, GameObject player)
    {
        _attackCooldownLeft -= Time.deltaTime;

        if (_canAttack && _attackCooldownLeft <= 0f && player != null)
        {
            _attackCooldownLeft = attackCooldown;
            player.GetComponent<IHealth>().TakeDamage(_damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
