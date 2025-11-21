using UnityEngine;

public class PushRight : MonoBehaviour
{
    public float pushForce = 5f;
    public float gravityScaleInZone = 0.5f;
    public float maxRightSpeed = 5f;

    private float cachedGravity = 1f;
    private Rigidbody2D cachedRb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        

        // prefer attachedRigidbody; fallback to GetComponentInParent/Children
        Rigidbody2D rb = other.attachedRigidbody ?? other.GetComponentInParent<Rigidbody2D>() ?? other.GetComponentInChildren<Rigidbody2D>();
        if (rb == null) return;

        cachedRb = rb;
        cachedGravity = rb.gravityScale;

        rb.velocity = new Vector2(5f, rb.velocity.y);

        // single impulse to the right
        rb.AddForce(Vector2.right * pushForce, ForceMode2D.Impulse);

        // reduce gravity while in the zone if desired
        rb.gravityScale = gravityScaleInZone;
    }

    private void OnTriggerStay2D(Collider2D other)
{
    if (!other.CompareTag("Player")) return;

    Rigidbody2D rb = other.attachedRigidbody ?? other.GetComponentInParent<Rigidbody2D>() ?? other.GetComponentInChildren<Rigidbody2D>();
    if (rb == null) return;

    // Try AddForce first
    rb.AddForce(Vector2.right * pushForce, ForceMode2D.Force);

    // If AddForce is being overridden by other code, enforce a minimum rightward speed
    if (rb.velocity.x < maxRightSpeed * 0.5f) // adjust threshold as needed
    {
        rb.velocity = new Vector2(Mathf.Min(maxRightSpeed, rb.velocity.x + pushForce * Time.fixedDeltaTime), rb.velocity.y);
    }

    // Clamp so it doesn't exceed maxRightSpeed
    if (rb.velocity.x > maxRightSpeed)
        rb.velocity = new Vector2(maxRightSpeed, rb.velocity.y);
}


    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        if (cachedRb == null) return;

        // restore original gravity
        cachedRb.gravityScale = cachedGravity;

        // clear cached reference
        cachedRb = null;
    }
}
