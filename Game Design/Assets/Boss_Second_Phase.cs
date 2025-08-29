using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Second_Phase : StateMachineBehaviour
{
    public float maxChaseSpeed = 10f;
    public float addForce = 5f;
    public float attackRange = 10f;
    public float spellRange = 20f;

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
        rb.velocity = Vector2.right * 5f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lookAtPlayer.LookAtPlayer();

        float direction = Mathf.Sign(player.position.x - rb.position.x);
        rb.velocity = new Vector2(direction * maxChaseSpeed * addForce, rb.velocity.y);
        float horizontalDistance = Mathf.Abs(player.position.x - rb.position.x);

        if (horizontalDistance <= attackRange)
        {
            if (Random.value < 0.5f)
            {
                Debug.Log("");
                animator.SetTrigger("AttackSecondPhase");
            }
        }
        else if (horizontalDistance >= spellRange)
        {
            if (Random.value < 0.5f)
            {
                Debug.Log("");
                animator.SetTrigger("SpellSecondPhase");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AttackSecondPhase");
        animator.ResetTrigger("SpellSecondPhase");
    }
}