using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField] private float bossMaxHealth = 50f;
    private float bossCurrentHealth;
    private Animator animator;

    private void Awake()
    {
        bossCurrentHealth = bossMaxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeBossDamage(float damage)
    {
        bossCurrentHealth -= damage;

        if (bossCurrentHealth > 0)
        {
            //animator.SetTrigger("Hit");
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 1f);
    }
}
