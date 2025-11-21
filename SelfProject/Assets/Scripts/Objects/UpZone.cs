using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpZone : MonoBehaviour
{
    public float floatForce = 5f; 
    public float gravityScaleInZone = 0.1f;
    public float maxUpwardSpeed = 5f;

    private float cachedGravity = 4f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            cachedGravity = rb.gravityScale;

            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Impulse);
            rb.gravityScale = gravityScaleInZone;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * floatForce, ForceMode2D.Force);

            if (rb.velocity.y > maxUpwardSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxUpwardSpeed);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            
            rb.gravityScale = cachedGravity;
        }
    }
    

}
