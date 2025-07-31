using UnityEngine;
using UnityEngine.Rendering;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private int deathSceneIndex = 2;

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
                SceneManager.LoadSceneAsync(2);
            }
        }
    }

    public void AddHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startingHealth);
    }
}


    /*
    private IEnumerator DisableColliderTemporarily(Collider2D collider)
    {
        collider.enabled = false;
        yield return new WaitForSeconds(1f);
        collider.enabled = true;
    }
}\
*/
