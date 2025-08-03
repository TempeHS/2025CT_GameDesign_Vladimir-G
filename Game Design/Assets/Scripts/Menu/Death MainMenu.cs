using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMainMenu : MonoBehaviour
{
    public void Retry()
    {
        int lastIndex = PlayerPrefs.GetInt("LastLevelIndex", 7);
        SceneManager.LoadSceneAsync(lastIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(7);
    }
}
