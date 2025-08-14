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
            transform.localScale = new Vector3(12, 12, 12);
        }
        else
        {
            transform.position += Vector3.left * chaseSpeed * Time.deltaTime;
            transform.localScale = new Vector3(-12, 12, 12);
        }
    }


    public void BossFlee()
    {
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

        int randomNumber = Random.Range(0, 2);

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
}


//float elasped = 0f;

/*while (elasped < 4f)
{
    if (randomNumber == 0)
    {
        BossChase();
    }
    else
    {
        BossFlee();
    }

    elasped += Time.deltaTime;
    yield return null;
}*/