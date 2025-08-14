using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float speed = 4;
    public float chaseSpeed = 8;
    public float chaseDuration = 4f;
    private Animator animator;
    public Transform playerTransform;
    private bool startLoop = true;
    [SerializeField] private Rigidbody2D rb;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void BossChase()
    {
        Debug.Log("Boss is chasing the player!");

        if (playerTransform.position.x > transform.position.x)
        {
            Vector3 targetVelocity = new Vector2(playerTransform.position.x - transform.position.x, 0);
            targetVelocity.Normalize();
            rb.AddForce(targetVelocity * chaseSpeed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(-12, 12, 12);
        }
        else
        {
            Vector3 targetVelocity = new Vector2(playerTransform.position.x - transform.position.x, 0);
            targetVelocity.Normalize();
            rb.AddForce(targetVelocity * chaseSpeed, ForceMode2D.Impulse);
            transform.localScale = new Vector3(12, 12, 12);
        }
    }


    public void BossFlee()
    {
        Debug.Log("Boss is fleeing from the player!");

        if (playerTransform.position.x > transform.position.x)
        {
            transform.position -= Vector3.right * chaseSpeed * Time.deltaTime;
            transform.localScale = new Vector3(12, 12, 12);
        }
        else
        {
            transform.position -= Vector3.left * chaseSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-12, 12, 12);
        }
    }


    public void Update()
    {
        if (startLoop)
        {
            startLoop = false;
            StartCoroutine(PickActionLoop());
        }
    }


    private IEnumerator PickActionLoop()
    {
        Debug.Log("Starting action loop...");

        int randomNumber = Random.Range(0, 1);

        if (randomNumber == 0)
        {
            BossChase();
        }
        else
        {
            BossFlee();
        }

        yield return new WaitForSeconds(5f);
        startLoop = true;
    }

    /*
        private void Flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    */
}