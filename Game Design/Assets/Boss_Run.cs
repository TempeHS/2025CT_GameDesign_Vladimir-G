using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss_Run : StateMachineBehaviour
{
    public float maxChaseSpeed = 1f;
    public float addForce = 1f;
    public float attackRange = 100f;
    public float spellRange = 100f;

    private float attackRangeSquare;

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
        attackRangeSquare = attackRange * attackRange;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lookAtPlayer.LookAtPlayer();

        float direction = Mathf.Sign(player.position.x - rb.position.x);

        rb.velocity = new Vector2(direction * maxChaseSpeed * addForce, rb.velocity.y);

        float horizontalDistance = Mathf.Abs(player.position.x - rb.position.x);

        Vector2 delta = (Vector2)player.position - rb.position;
        float squareDistance = delta.sqrMagnitude;
        Debug.Log("LocatedDistance");

        if (squareDistance <= attackRangeSquare)
        {
            Debug.Log("InAttackRange");
            animator.SetTrigger("Attack");
        }

        if (horizontalDistance >= spellRange)
        {

        }

        if (bossHp != null && bossHp.bossCurrentHealth == 25)
        {
            animator.SetBool("secondPhase", true);
            animator.ResetTrigger("Attack");
            Debug.Log("BossChangeState");
            rb.velocity = Vector2.zero;
            return;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
