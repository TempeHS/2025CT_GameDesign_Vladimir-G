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

        Debug.Log($" chase → dir:{direction} targetSpeed:{maxChaseSpeed} currentDrag:{rb.drag}");

        if (horizontalDistance <= attackRange)
        {
            if (Random.value < 0.1f)
            {
                lookAtPlayer.LookAtPlayer();
                animator.SetTrigger("Attack");
            }
        }
        else if (horizontalDistance >= spellRange)
        {
            if (Random.value < 0.1f)
            {
                lookAtPlayer.LookAtPlayer();
                animator.SetTrigger("CastSpell");
            }
        }

        if (bossHp.bossCurrentHealth < 25)
        {
            animator.SetBool("secondPhase", true);
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("CastSpell");
            lookAtPlayer.LookAtPlayer();
            Debug.Log("BossChangeState");
            Debug.Log($" chase transtiiton 1 → dir:{direction} targetSpeed:{maxChaseSpeed} currentDrag:{rb.drag}");
            return;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("CastSpell");
    }
}
