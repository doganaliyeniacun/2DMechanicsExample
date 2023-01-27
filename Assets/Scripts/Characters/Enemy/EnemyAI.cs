using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 playerPos;

    [SerializeField]
    private LayerMask playerLayerMask;

    [SerializeField]
    private float

            radius = 5f,
            moveSpeed = 5f;

    public bool canFindPlayer = true;

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
        Direction(playerPos - (Vector2) transform.position);
    }

    private void FindPlayer()
    {
        rb.velocity = Vector2.zero;

        Collider2D player =
            Physics2D
                .OverlapCircle(transform.position, radius, playerLayerMask);

        if (player != null)
        {
            playerPos = player.gameObject.transform.position;

            Vector2 pos =
                Vector2
                    .MoveTowards(transform.position,
                    new Vector2(playerPos.x, transform.position.y),
                    moveSpeed * Time.fixedDeltaTime);

            rb.MovePosition (pos);
        }
    }

    private void Direction(Vector2 direction)
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
