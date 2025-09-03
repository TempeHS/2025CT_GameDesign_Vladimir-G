using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth = 3f;
    [SerializeField] private float stunDuration = 1.5f;
    private float enemyCurrentHealth;
    private Animator animator;
    private FlyingEnemyMovement movement;



    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
        animator = GetComponent<Animator>();
        movement = GetComponent<FlyingEnemyMovement>();
    }

    public void TakeDamage(float damage)
    {
        enemyCurrentHealth -= damage;

        if (enemyCurrentHealth > 0)
        {
            StartCoroutine(DisableMovementTemporarily());
        }
        else
        {
            if (enemyCurrentHealth <= 0)
            {
                GetComponent<FlyingEnemyMovement>().enabled = false;
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator DisableMovementTemporarily()
    {
        movement.enabled = false;
        animator.SetBool("isFlying", false);
        animator.SetBool("isFlyingHit", true);
        yield return new WaitForSeconds(stunDuration);
        animator.SetBool("isFlyingHit", false);
        animator.SetBool("isFlying", true);
        movement.enabled = true;
    }
}
