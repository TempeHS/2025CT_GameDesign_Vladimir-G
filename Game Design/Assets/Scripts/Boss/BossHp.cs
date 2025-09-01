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
        else if (bossCurrentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.ResetTrigger("AttackSecondPhase");
        animator.ResetTrigger("SpellSecondPhase");
        animator.SetBool("secondPhase", false);
        animator.SetTrigger("isDead");
        Destroy(gameObject, 0.8f);
        StartCoroutine(FinishGame());
    }

    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(0.7f);
        gameFinish.SetActive(true);
    }

    private IEnumerator BossLostHp()
    {
        animator.SetBool("isHurt", true);
        yield return new WaitForSeconds(hitDuration);
        animator.SetBool("isHurt", false);
    }
}
