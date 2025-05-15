using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float roomWidth;  // Width of the room
    public float roomHeight; // Height of the room
    public float smoothSpeed = 5f; // Adjust transition speed

    public void SmoothMoveCamera(Vector3 targetPosition, float targetSize)
    {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * smoothSpeed);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, Time.deltaTime * smoothSpeed);
    }
}