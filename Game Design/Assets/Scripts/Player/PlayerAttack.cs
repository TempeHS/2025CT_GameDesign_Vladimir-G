using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float bounceForce = 12f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weak"))
        {
            EnemyHealth enemy = other.GetComponentInParent<EnemyHealth>();
            if (enemy == null) return;

            enemy.TakeDamage(1f);

            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            if (rb == null) return;

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }

        if (other.CompareTag("bossWeakPoint"))
        {
            BossHp bossHp = other.GetComponentInParent<BossHp>();
            if (bossHp == null) return;

            bossHp.TakeBossDamage(1f);

            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            if (rb == null) return;

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);

            Debug.Log("PlayerDidDamage");
        }
    }
}