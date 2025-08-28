using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpellCast : MonoBehaviour
{
    public int spellDamage = 1;

    public Vector3 spellOffset;
    public float spellRange = 1f;
    public LayerMask spellMask;

    public void Spell()
    {
        float sign = Mathf.Sign(transform.lossyScale.x);

        Vector3 pos = transform.position;
        pos += transform.right * (spellOffset.x * sign);
        pos += transform.up * spellOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, spellRange, spellMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Health>().TakeDamage(spellDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 pos = transform.position;
        pos += transform.right * spellOffset.x;
        pos += transform.up * spellOffset.y;
        Gizmos.DrawWireSphere(pos, spellRange);
    }

    

}
