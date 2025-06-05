using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 1;

    [SerializeField] private BoxCollider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            
        }
    }

}
