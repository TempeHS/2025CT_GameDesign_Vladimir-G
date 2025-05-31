using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 8;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite NoHeart;

    void Update()
    {
        if (health == 8)
        {
            heart3.GetComponent<Image>().sprite = FullHeart;
        }
        else if (health == 7)
        {
            heart3.GetComponent<Image>().sprite = HalfHeart;
        }
        else if (health == 6)
        {
            heart3.GetComponent<Image>().sprite = NoHeart;
        }
        else if (health == 5)
        {
            heart2.GetComponent<Image>().sprite = FullHeart;
        }
        else if (health == 4)
        {
            heart2.GetComponent<Image>().sprite = HalfHeart;
        }
        else if (health == 3)
        {
            heart2.GetComponent<Image>().sprite = NoHeart;
        }
        else if (health == 2)
        {
            heart1.GetComponent<Image>().sprite = FullHeart;
        }
        else if (health == 1)
        {
            heart1.GetComponent<Image>().sprite = HalfHeart;
        }
        else if (health == 0)
        {
            heart1.GetComponent<Image>().sprite = NoHeart;
        }
        
    }

    public void noHealth()
    {
        health = 0;
        heart1.GetComponent<Image>().sprite = NoHeart;
        heart2.GetComponent<Image>().sprite = NoHeart;
        heart3.GetComponent<Image>().sprite = NoHeart;
    }
    
    public void fullHealth()
    {
        health = 8;
        heart1.GetComponent<Image>().sprite = FullHeart;
        heart2.GetComponent<Image>().sprite = FullHeart;
        heart3.GetComponent<Image>().sprite = FullHeart;
    }
}
