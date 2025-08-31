using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFinish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(8);
        }
    }
}
