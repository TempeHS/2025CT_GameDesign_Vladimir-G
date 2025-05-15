using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public Camera mainCamera;
    public float smoothSpeed = 5f; // Speed of camera transition

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room")) // Ensure this matches the "Room" tag
        {
            Debug.Log($"RoomManager detected room: {other.name}"); // Debug log for room detection
            AdjustCameraToRoom(other); // Pass Collider directly
        }
    }

    public void AdjustCameraToRoom(Collider room)
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned in RoomManager!");
            return;
        }

        if (room == null)
        {
            Debug.LogWarning("Room collider is null!");
            return;
        }

        float roomWidth = room.bounds.size.x;
        float roomHeight = room.bounds.size.y;

        // Log the room's width and height
        Debug.Log($"Room detected: {room.name}, Width: {roomWidth}, Height: {roomHeight}");

        float aspectRatio = Screen.width / (float)Screen.height;
        float targetSize = Mathf.Max(roomWidth / aspectRatio, roomHeight) / 2f;

        // Use the current camera's Z position
        float cameraHeight = mainCamera.transform.position.z;
        Vector3 targetPosition = new Vector3(room.bounds.center.x, room.bounds.center.y, cameraHeight);

        Debug.Log($"Moving camera immediately to position: {targetPosition}, size: {targetSize}");

        // Move the camera immediately
        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = targetSize;
    }
}

