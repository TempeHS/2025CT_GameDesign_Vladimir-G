using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMainMenu : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
