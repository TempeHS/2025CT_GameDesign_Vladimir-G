using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    [SerializeField] private float bossMaxHealth = 50f;
    public float bossCurrentHealth;
    private Animator animator;
    private float hitDuration = 1f;
    [SerializeField] GameObject gameFinish;
    [SerializeField] BossHealthBar healthBar;

    private void Awake()
    {
        bossCurrentHealth = bossMaxHealth;
        animator = GetComponent<Animator>();
        healthBar = GetComponentInChildren<BossHealthBar>();
    }

    public void TakeBossDamage(float damage)
    {
        bossCurrentHealth -= damage;
        healthBar.UpdateHealthBar(bossCurrentHealth, bossMaxHealth);

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
        gameFinish.SetActive(true);
    }

    private IEnumerator BossLostHp()
    {
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(hitDuration);
        animator.SetBool("isHurt", false);
    }
}
