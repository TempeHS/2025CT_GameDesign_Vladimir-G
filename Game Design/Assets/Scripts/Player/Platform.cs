using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DropThrough : MonoBehaviour
{

    [SerializeField] private float dropDuration = 0.5f;
    private Collider2D playerCollider;
    [SerializeField] private CompositeCollider2D platformCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            StartCoroutine(Drop());
    }

    private IEnumerator Drop()
    {
        Physics2D.IgnoreCollision(playerCollider, platformCollider, true);
        yield return new WaitForSeconds(dropDuration);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
