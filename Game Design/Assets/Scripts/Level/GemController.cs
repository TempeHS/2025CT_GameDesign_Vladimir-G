using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GemController : MonoBehaviour
{
    public int gemCount;
    [SerializeField] public int gemTotal;
    public TMP_Text gemText;
    public GameObject key;


    void Update()
    {
        gemText.text = ": " + gemCount.ToString();

        if (gemCount == gemTotal)
        {
            key.SetActive(true);
        }
    }

}
