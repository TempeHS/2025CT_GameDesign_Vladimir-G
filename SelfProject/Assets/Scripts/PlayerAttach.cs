using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAttach : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject roofCheck;
    public LayerMask layerMask;
    public float jumpForce = 12f;
    public float checkRadius = 0.12f;
    public float moveSpeed = 0.01f;

    private bool isAttached;
    private Transform attachedRoof; // current roof transform

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // horizontal movement
        float h = Input.GetAxisRaw("Horizontal");

        if (isAttached)
        {
            // move relative to roof while attached (local movement)
            if (Mathf.Abs(h) > 0.01f)
            {
                // move on local X so movement follows roof orientation
                transform.localPosition += new Vector3(h * moveSpeed * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DetachAndJump();
            }
        }
        else
        {
            // normal grounded or air movement using physics velocity
            // modify this to match your existing movement code
            Vector2 v = rb.velocity;
            v.x = h * moveSpeed;
            rb.velocity = v;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryAttachToRoof();
            }
        }
    }

    void TryAttachToRoof()
    {
        if (roofCheck == null) return;

        Collider2D hit = Physics2D.OverlapCircle(roofCheck.transform.position, checkRadius, layerMask);
        if (hit != null)
        {
            // parent the player to the roof so we follow moving roofs and can move locally
            attachedRoof = hit.transform;
            transform.SetParent(attachedRoof, true);

            // disable physics while attached so it won't fall or jitter
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            rb.simulated = false;

            isAttached = true;
        }
    }

    void DetachAndJump()
    {
        if (!isAttached) return;

        // unparent and re-enable physics
        transform.SetParent(null, true);
        rb.simulated = true;
        rb.isKinematic = false;

        // apply jump
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        attachedRoof = null;
        isAttached = false;
    }

    void OnDrawGizmosSelected()
    {
        if (roofCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(roofCheck.transform.position, checkRadius);
        }
    }
}
