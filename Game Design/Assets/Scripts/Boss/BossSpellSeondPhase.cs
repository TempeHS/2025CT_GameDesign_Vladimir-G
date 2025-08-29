using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellSeondPhase : MonoBehaviour
{ 
    public int spellDamage = 1;

    public Vector3 spellOffsetSecondPhase;
    public float spellRangeSecondPhase = 1f;
    public LayerMask spellMask;

    public void SpellSecondPhase()
    {
        float sign = Mathf.Sign(transform.lossyScale.x);

        Vector3 pos = transform.position;
        pos += transform.right * (spellOffsetSecondPhase.x * sign);
        pos += transform.up * spellOffsetSecondPhase.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, spellRangeSecondPhase, spellMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Health>().TakeDamage(spellDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 pos = transform.position;
        pos += transform.right * spellOffsetSecondPhase.x;
        pos += transform.up * spellOffsetSecondPhase.y;
        Gizmos.DrawWireSphere(pos, spellRangeSecondPhase);
    }
}
