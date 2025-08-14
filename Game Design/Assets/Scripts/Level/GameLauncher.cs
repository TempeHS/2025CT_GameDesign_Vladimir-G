using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private static bool hasInitialized = false;

    void Awake()
    {
        if (hasInitialized)
            return;

        hasInitialized = true;
        DontDestroyOnLoad(gameObject);
        resetProgress();
    }

    private void resetProgress()
    {
        PlayerPrefs.DeleteKey("UnlockedLevel");
        PlayerPrefs.DeleteKey("ReachedIndex");

        PlayerPrefs.SetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("ReachedIndex", 1);

        PlayerPrefs.Save();
    }
}
