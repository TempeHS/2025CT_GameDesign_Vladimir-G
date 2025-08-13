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


    void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void BossChase()
    {
        
    }
    

    public void BossFlee()
    {

    }


    public void PickAction()
    {
        int randomNumber = Random.Range(0, 1);

        if (randomNumber == 0)
        {
            BossChase();
        }
        else
        {
            BossFlee();
        }
    }


    public void Update()
    {

    }
}

