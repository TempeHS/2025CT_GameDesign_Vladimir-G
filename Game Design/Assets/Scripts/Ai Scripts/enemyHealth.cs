using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyMaxHealth = 3f;
    [SerializeField] private float stunDuration = 1.5f;
    private float enemyCurrentHealth;
    private Animator animator;
    private enemyMovement movement;



    private void Awake()
    {
        enemyCurrentHealth = enemyMaxHealth;
        animator = GetComponent<Animator>();
        movement = GetComponent<enemyMovement>();
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
                GetComponent<enemyMovement>().enabled = false;
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
        animator.SetBool("isRunning", false);
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(stunDuration);
        animator.SetBool("isHit", false);
        animator.SetBool("isRunning", true);
        movement.enabled = true;
    }
}
