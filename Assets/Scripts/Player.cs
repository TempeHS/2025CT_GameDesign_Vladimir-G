using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider playerCollider; // Reference to the player's BoxCollider
    private Rigidbody playerRigidbody; // Reference to the player's Rigidbody
    public float moveSpeed = 5f; // Speed of player movement

    void Start()
    {
        playerCollider = GetComponent<BoxCollider>();
        if (playerCollider != null)
        {
            // Adjust the size and center of the BoxCollider
            playerCollider.size = new Vector3(1f, 1f, 1f); // Example size
            playerCollider.center = new Vector3(0f, 0.5f, 0f); // Example center
        }

        playerRigidbody = GetComponent<Rigidbody>();
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true;
        }
    }

    void Update()
    {
        // WASD movement logic
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down

        // Apply vertical input to the Y-axis instead of the Z-axis
        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
