using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeaponSecondPhase : MonoBehaviour
{
    public int attackDamage = 2;

    public Vector3 attackOffsetSecondPhase;
    public float attackRangeSecondPhase = 1f;
    public LayerMask attackMask;

    public void AttackSecondPhase()
    {
        float sign = Mathf.Sign(transform.lossyScale.x);

        Vector3 pos = transform.position;
        pos += transform.right * (attackOffsetSecondPhase.x * sign);
        pos += transform.up * attackOffsetSecondPhase.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRangeSecondPhase, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Health>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 pos = transform.position;
        pos += transform.right * attackOffsetSecondPhase.x;
        pos += transform.up * attackOffsetSecondPhase.y;
        Gizmos.DrawWireSphere(pos, attackRangeSecondPhase);
    }
}
