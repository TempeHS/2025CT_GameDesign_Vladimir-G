using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAtPlayer : MonoBehaviour
{
    public Transform player;
    public bool isFacingRight;
    public void LookAtPlayer()
    {
        if (player.position.x > transform.position.x && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        else if (player.position.x < transform.position.x && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= 1f;
            transform.localScale = localScale;
        }
    }

    
}
