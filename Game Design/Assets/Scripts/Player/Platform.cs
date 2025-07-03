using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DropThrough : MonoBehaviour
{
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
        yield return new WaitForSeconds(0.18f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
