using System.Collections;
using UnityEngine;

public class DropThrough : MonoBehaviour
{
    [SerializeField] private PlatformEffector2D effector;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(Drop());
    }

    private IEnumerator Drop()
    {
        effector.enabled = false;  // turn off one‐way for this frame
        yield return null;         // wait one frame
        effector.enabled = true;   // restore one‐way
    }
}
