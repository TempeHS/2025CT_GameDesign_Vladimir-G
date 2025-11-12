using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontalInput;
    private Rigidbody2D rb;
    private float moveSpeed = 5f;

    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
    

}
