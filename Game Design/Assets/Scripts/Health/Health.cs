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

    public Collider2D playerCollider;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
            StartCoroutine(DisableColliderTemporarily(collider: playerCollider));
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
            yield return new WaitForSeconds(1f); // Wait for the death animation to finish
        gameOverText.gameObject.SetActive(true);
        Destroy(gameObject); // Destroy the player object
    }

    public void AddHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);
    }

    private IEnumerator DisableColliderTemporarily(Collider2D collider)
    {
        collider.enabled = false;
        yield return new WaitForSeconds(1f);
        collider.enabled = true;
    }
}
