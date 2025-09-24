using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss_Second_Phase : StateMachineBehaviour
{
    public float maxChaseSpeed = 1f;
    public float addForce = 1f;
    public float attackRange = 10f;
    public float spellRange = 20f;
    float nextActionTime = 0f;
    public float actionInterval = 5f;

    Transform player;
    Rigidbody2D rb;
    BossLookAtPlayer lookAtPlayer;
    BossHp bossHp;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        lookAtPlayer = animator.GetComponent<BossLookAtPlayer>();
        bossHp = animator.GetComponent<BossHp>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lookAtPlayer.LookAtPlayer();

        float direction = Mathf.Sign(player.position.x - rb.position.x);
        rb.velocity = new Vector2(direction * maxChaseSpeed * addForce, rb.velocity.y);
        float horizontalDistance = Mathf.Abs(player.position.x - rb.position.x);

        lookAtPlayer.LookAtPlayer();


        Debug.Log($"secondPhase → dir:{direction} targetSpeed:{maxChaseSpeed} currentDrag:{rb.drag} addForce{addForce}");


        if (Time.time < nextActionTime)
        {
            return;
        }

        if (Random.value < 0.5f)
        {
            lookAtPlayer.LookAtPlayer();
            animator.SetTrigger("AttackSecondPhase");
            nextActionTime = Time.time + actionInterval;
            lookAtPlayer.LookAtPlayer();
        }
        else
        {
            lookAtPlayer.LookAtPlayer();
            animator.SetTrigger("SpellSecondPhase");
            nextActionTime = Time.time + actionInterval;
            lookAtPlayer.LookAtPlayer();
        }

        if (bossHp.bossCurrentHealth == 1)
        {
            animator.SetBool("isDead", true);
            animator.ResetTrigger("AttackSecondPhase");
            animator.ResetTrigger("SpellSecondPhase");
            return;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AttackSecondPhase");
        animator.ResetTrigger("SpellSecondPhase");
    }
}



