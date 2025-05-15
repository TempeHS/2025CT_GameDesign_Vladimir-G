using UnityEngine;

public class DebugCollisionTester : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Object {gameObject.name} collided with: {other.name}");
    }
}
