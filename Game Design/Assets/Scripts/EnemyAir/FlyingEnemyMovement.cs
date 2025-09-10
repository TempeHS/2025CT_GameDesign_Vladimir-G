using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEnemyMovement : MonoBehaviour
{
    public float speed;
    public float chaseRadius = 8f;
    public bool chase = false;
    public Transform startingPoint;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null)
            return;

        if (Vector2.Distance(transform.position, player.position) <= chaseRadius)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            chase = distance <= chaseRadius;

            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            Flip();
        }
        else
        {
            ReturnToStart();
        }
    }

    private void ReturnToStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
