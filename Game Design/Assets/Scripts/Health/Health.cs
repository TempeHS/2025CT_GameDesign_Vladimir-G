using UnityEngine;
using UnityEngine.Rendering;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //playerHurt
        }
        else
        {
            //player dead
        }
    }

    private void Update()
    {
        if (input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(1);
        }
    }

}
