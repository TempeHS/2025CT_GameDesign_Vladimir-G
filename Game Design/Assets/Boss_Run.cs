using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss_Run : StateMachineBehaviour
{
    public float maxChaseSpeed = 1f;
    public float addForce = 1f;
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
                Debug.Log("Attack Triggered");
                animator.SetTrigger("Attack");
            }
        }
        else if (horizontalDistance >= spellRange)
        {
            if (Random.value < 0.5f)
            {
                Debug.Log("Spell Triggered");
                animator.SetTrigger("CastSpell");
            }
        }

        if (bossHp != null && bossHp.bossCurrentHealth == 47)
        {
            animator.SetBool("secondPhase", true);
            animator.ResetTrigger("Attack");
            Debug.Log("BossChangeState");
            return;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("CastSpell");
    }
}
