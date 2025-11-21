using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUp : MonoBehaviour
{
    public float upwardsForce = 1600f;
    public float maxUpwardSpeed = 50f;
    private Rigidbody2D rb;
    bool flying = false;
    float originalGravityScale;
    public bool disableGravityWhileFlying = true;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W pressed, flying toggled: " + !flying);
            flying = !flying;
            if (disableGravityWhileFlying)
                rb.gravityScale = flying ? 0f : originalGravityScale;

        }
    }


    void FixedUpdate()
    {
        if (!flying) return;

        rb.AddForce(Vector2.up * upwardsForce, ForceMode2D.Force);

         Vector2 v = rb.velocity;
            v.y = Mathf.Min(v.y, maxUpwardSpeed);
            rb.velocity = v;
    }

}
