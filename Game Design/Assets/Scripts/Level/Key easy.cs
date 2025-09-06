using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyeasy : MonoBehaviour
{
    [SerializeField] GameObject gameFinish;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("key"))
        {
            gameFinish.SetActive(true);
            Destroy(other.gameObject);
        }
    }

}
