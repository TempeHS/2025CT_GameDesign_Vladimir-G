using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private int deathSceneIndex = 8;

    public float currentHealth { get; private set; }
    public float Iframes;

    private Animator animator;
    private bool dead;

    public Collider2D playerCollider;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();

    }

    void Update()
    {
        if (Iframes > 0)
        {
            Iframes -= Time.deltaTime;
        }
    }

    public void TakeDamage(float _damage)
    {
        if (Iframes > 0)
            return;

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0 && Iframes < 0)
        {
            animator.SetTrigger("hurt");
            Iframes = 1.5f;
            //StartCoroutine(DisableColliderTemporarily(collider: playerCollider));
        }
        else
        {
            if (!dead)
            {
                PlayerPrefs.SetInt("LastLevelIndex", SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadSceneAsync(deathSceneIndex);

                animator.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                SceneManager.LoadSceneAsync(8);
            }
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);
    }

    //private IEnumerator DisableColliderTemporarily(Collider2D collider)
    //{
    //    isInvulnerable = true;
    //    yield return new WaitForSeconds(invincibilityDuration);
    //    isInvulnerable = false;
    //}
}



