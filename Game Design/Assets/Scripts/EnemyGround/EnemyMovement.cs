using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] partrolPoints;
    public float speed;
    public float chaseSpeed;
    private int patrolDestination;
    private Animator animator;
    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistance;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        isChasing = Vector2.Distance(transform.position, playerTransform.position) <= chaseDistance;

        if (isChasing)
        {
            animator.SetBool("isRunning", true);
            if (playerTransform.position.x > transform.position.x)
            {
                transform.position += Vector3.right * chaseSpeed * Time.deltaTime;
                transform.localScale = new Vector3(7, 7, 7);
            }
            else
            {
                transform.position += Vector3.left * chaseSpeed * Time.deltaTime;
                transform.localScale = new Vector3(-7, 7, 7);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
            {
                isChasing = true;
                animator.SetBool("isRunning", true);
            }


            if (isChasing == false && patrolDestination == 0)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
}
