using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField] private float bossMaxHealth = 50f;
    private float bossCurrentHealth;
    private Animator animator;
    private float hitDuration = 1f;

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
            StartCoroutine(BossLostHp());
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

    private IEnumerator BossLostHp()
    {
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(hitDuration);
        animator.SetBool("isHurt", false);
    }
}
