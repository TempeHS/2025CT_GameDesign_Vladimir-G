using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id; // Unique identifier for the door
    public Door linkedDoor; // Reference to the door in another room
    public AudioClip doorSound; // Sound effect for the door
    private AudioSource audioSource;
    private Collider room; // Reference to the room's collider

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider doorCollider = GetComponent<BoxCollider>();
        if (doorCollider != null)
        {
            // Ensure the collider is a trigger and adjust its size
            doorCollider.isTrigger = true;
            doorCollider.size = new Vector3(1f, 2f, 0.5f); // Example size
            doorCollider.center = new Vector3(0f, 1f, 0f); // Example center
        }

        // Find the sibling tagged as "Room"
        room = FindRoomSibling();

        // Validate that the linkedDoor is assigned
        if (linkedDoor == null)
        {
            Debug.LogWarning($"Door {name} does not have a linkedDoor assigned!");
        }

        audioSource = GetComponent<AudioSource>();
    }

    private Collider FindRoomSibling()
    {
        if (transform.parent == null)
        {
            Debug.LogWarning($"Door {name} has no parent, cannot find sibling tagged as 'Room'.");
            return null;
        }

        foreach (Transform sibling in transform.parent)
        {
            if (sibling.CompareTag("Room"))
            {
                Collider roomCollider = sibling.GetComponent<Collider>();
                if (roomCollider != null)
                {
                    return roomCollider;
                }
                else
                {
                    Debug.LogWarning($"Sibling tagged as 'Room' does not have a Collider: {sibling.name}");
                }
            }
        }

        Debug.LogWarning($"No sibling tagged as 'Room' found for door: {name}");
        return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player entered the trigger
        {
            Debug.Log($"Player entered the trigger of door: {name}");
            PlayDoorEffect(); // Optional: Play sound or animation

            // Teleport the player to the linked door
            if (linkedDoor != null)
            {
                StartCoroutine(TeleportPlayer(other));
            }
            else
            {
                Debug.LogWarning($"Door {name} does not have a linkedDoor assigned!");
            }
        }
    }

    private IEnumerator TeleportPlayer(Collider player)
    {
        // Disable the player's collider to prevent immediate collision
        Collider playerCollider = player.GetComponent<Collider>();
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        // Move the player to the linked door's position
        player.transform.position = linkedDoor.transform.position;
        Debug.Log($"Player teleported to door: {linkedDoor.name}");

        // Adjust the camera to the new room immediately
        RoomManager roomManager = FindObjectOfType<RoomManager>();
        if (roomManager != null)
        {
            if (linkedDoor.room == null)
            {
                Debug.LogWarning($"Room is null for linked door: {linkedDoor.name}");
            }
            else
            {
                roomManager.AdjustCameraToRoom(linkedDoor.room); // Pass the correct room collider
            }
        }

        // Wait for 1 seconds before re-enabling the collider
        yield return new WaitForSeconds(1f);

        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }
    }

    public void PlayDoorEffect()
    {
        if (doorSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(doorSound);
        }
        // Add additional effects here (e.g., animations or particles)
    }
}
