using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform[] partrolPoints;
    public float speed;
    private int patrolDestination;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (patrolDestination == 0)
        {
            animator.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, partrolPoints[0].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, partrolPoints[0].position) < 0.5f)
            {
                transform.localScale = new Vector3(7, 7, 7);
                patrolDestination = 1;
            }
        }
        else if (patrolDestination == 1)
        {
            animator.SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, partrolPoints[1].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, partrolPoints[1].position) < 0.5f)
            {
                transform.localScale = new Vector3(-7, 7, 7);
                patrolDestination = 0;
            }
        }
    }
}
