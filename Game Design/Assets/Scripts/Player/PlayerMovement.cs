using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float JumpingPower = 15f;
    private float dashingPower = 18f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private float wallSlidingSpeed = 2f;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.4f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.5f;

    private Vector2 wallJumpingPower = new Vector2(8f, 15f);

    private bool isFacingRight = true;
    private bool doubleJump;
    private bool canDash = true;
    private bool isDashing;
    private bool isWallSliding;
    private bool isWallJumping;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Animator _animator;

    private Animator animator;

    private bool wasGrounded;

    void SetupAnimation()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        bool grounded = IsGrounded();

        // Set isJumping true when leaving ground
        if (!grounded && wasGrounded)
        {
            animator.SetBool("isJumping", true);
        }

        // Set isJumping false when landing
        if (grounded && !wasGrounded)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isWallJumping", false);
        }

        animator.SetBool("isWallJumping", isWallJumping);

        wasGrounded = grounded;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
                doubleJump = false;
                animator.SetBool("isDoubleJumping", true);
            }

            if ((horizontal < 0f && isFacingRight) || (horizontal > 0f && !isFacingRight))
            {
                Flip();
            }
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();

        WallSlide();

        WallJump();
        WallSlide();

        if (!isWallJumping)
        {
            Flip();
        }

        SetupAnimation();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {

        if (isDashing)
        {
            return;
        }

        if (!isWallJumping)
        {
            Flip();
        }

        if (isWallJumping)
        {
            return;
        }


        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        Vector2 velocity = rb.velocity;
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }


    private void Flip()
    {
        if (isWallJumping)
        {
            return;
        }

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = transform.localScale.x > 0 ? -1f : 1f;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;

            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        tr.emitting = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

