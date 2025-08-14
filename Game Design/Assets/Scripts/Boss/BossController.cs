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


    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void BossChase()
    {
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


    public void BossFlee()
    {
        if (playerTransform.position.x > transform.position.x)
            {
                transform.position -= Vector3.right * chaseSpeed * Time.deltaTime;
                transform.localScale = new Vector3(7, 7, 7);
            }
            else
            {
                transform.position -= Vector3.left * chaseSpeed * Time.deltaTime;
                transform.localScale = new Vector3(-7, 7, 7);
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
        int randomNumber = Random.Range(0, 2);
        float elasped = 0f;

        while (elasped < 4f)
        {
            if (randomNumber == 0) BossChase();
            else BossFlee();

            elasped += Time.deltaTime;
            yield return null;
        }
    }
}

