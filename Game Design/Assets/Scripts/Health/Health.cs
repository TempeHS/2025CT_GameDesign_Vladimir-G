using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private TMP_Text gameOverText;

    public float currentHealth { get; private set; }

    private Animator animator;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                animator.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                StartCoroutine(HandleDeath());
            }
        }
    }

    private IEnumerator HandleDeath()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f); // Wait for the death animation to finish
        Destroy(gameObject); // Destroy the player object
    }
}
