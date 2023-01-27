using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private Vector2 moveInput;

    private bool

            checkGround,
            dashing,
            canDash = true,
            canWallJump,
            wallJumping;

    [SerializeField]
    private float

            moveSpeed = 5f,
            jumpForce = 10f,
            dashingTime = 1f,
            dashingCooldown = 1f,
            dashForce = 5f,
            wallJumpingCooldown = 1f;

    [SerializeField]
    private TrailRenderer tr;

    private void OnEnable()
    {
        PlayerManager.MoveEvents += MoveInput;
        PlayerManager.JumpEvents += Jump;
        PlayerManager.DashEvents += Dash;
    }

    private void OnDisable()
    {
        PlayerManager.MoveEvents -= MoveInput;
        PlayerManager.JumpEvents -= Jump;
        PlayerManager.DashEvents -= Dash;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (dashing)
        {
            return;
        }

        Move (moveInput, moveSpeed);
    }

    private void Update()
    {
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            checkGround = true;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            canWallJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            checkGround = false;
        }
    }

    //Events
    private void MoveInput(Vector2 input)
    {
        moveInput = input;
    }

    private void Jump()
    {
        if (checkGround)
        {
            Jumping(jumpForce);
        }
        else if (canWallJump)
        {
            Jumping(jumpForce * 1.5f);
            WallJump();
        }
    }

    private void Jumping(float jumpForce)
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
    }

    private void WallJump()
    {
        if (canWallJump) StartCoroutine(WallJumping());
    }

    private IEnumerator WallJumping()
    {
        canWallJump = false;
        tr.emitting = true;
        
        yield return new WaitForSeconds(wallJumpingCooldown);        
        tr.emitting = false;
        
    }

    //Mechanics
    private void Move(Vector2 input, float moveSpeed)
    {
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);
    }

    private void Dash()
    {
        if (canDash) StartCoroutine(Dashing());
    }

    private IEnumerator Dashing()
    {
        canDash = false;
        dashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        tr.emitting = true;

        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        dashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;

        if (moveInput.x != 0)
        {
            localScale.x = moveInput.x;
            transform.localScale = localScale;
        }
    }
}
