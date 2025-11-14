using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject groundCheck;
    public LayerMask layerMask;
    public float jumpForce = 12f;
    public float checkRadius = 0.12f;
    bool IsGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (layerMask == 0) layerMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (groundCheck != null)
        {
            IsGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, layerMask) != null;
        }
        else
        {
            IsGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
        }
    }
}
