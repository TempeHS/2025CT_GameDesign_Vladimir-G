using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 6;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite FullHeart;
    public Sprite HalfHeart;
    public Sprite NoHeart;

    void Update()
    {
        if (health == 6)
        {
            heart3.sprite = FullHeart;
        }
        else if (health == 5)
        {
            heart3.sprite = HalfHeart;
        }
        else if (health == 4)
        {
            heart3.sprite = NoHeart;
        }
        else if (health == 3)
        {
            heart2.sprite = FullHeart;
        }
        else if (health == 2)
        {
            heart2.sprite = HalfHeart;
        }
        else if (health == 1)
        {
            heart2.sprite = NoHeart;
        }
        else if (health == 0)
        {
            heart1.sprite = NoHeart;
        }
    }
    
    public void noHealth()
    {
        health = 0;
        heart1.sprite = NoHeart;
        heart2.sprite = NoHeart;
        heart3.sprite = NoHeart;
    }
}
