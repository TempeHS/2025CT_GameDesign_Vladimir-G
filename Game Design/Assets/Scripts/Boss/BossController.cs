using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BossController : MonoBehaviour
{
    public float speed = 10;
    public float chaseSpeed = 12;
    private Animator animator;
    public Transform playerTransform;
    private bool startLoop = true;
    [SerializeField] private Rigidbody2D rb;
    public float chaseDuration = 5;
    private bool isFacingRight;
    [SerializeField] private LayerMask wallLayer;
    private CapsuleCollider2D capsuleCollider;
    //private bool flippedDuringChase; !flippedDuringChase



    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInChildren<Rigidbody2D>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider2D>();
    }


    public void BossChase()
    {
        Debug.Log("Boss is chasing the player!");

        if (isWall())
        {
            Flip();
            Debug.Log("flipped");
            //flippedDuringChase = true;
       
            return;
        }

        if (playerTransform.position.x > transform.position.x)
            {
                Vector3 targetVelocity = new Vector2(playerTransform.position.x - transform.position.x, 0);
                targetVelocity.Normalize();
                rb.AddForce(targetVelocity * chaseSpeed, ForceMode2D.Impulse);

            }
            else
            {
                Vector3 targetVelocity = new Vector2(playerTransform.position.x - transform.position.x, 0);
                targetVelocity.Normalize();
                rb.AddForce(targetVelocity * chaseSpeed, ForceMode2D.Impulse);
            }
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Flip();
            Debug.Log("Boss colided with wall and flips");
        }
    }


    private bool isWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    


    public IEnumerator BossChasePlayer()
    {
        Debug.Log("BossChasePlayerTriggered");

        float time = 0f;

        while (time < chaseDuration)
        {
            BossChase();
            time += Time.deltaTime;
            yield return null;
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
            StartCoroutine(BossChasePlayer());
            Debug.Log("Boss is chasing the player");
        }
        else
        {
            BossFlee();
        }

        yield return new WaitForSeconds(6f);
        startLoop = true;
    }
}