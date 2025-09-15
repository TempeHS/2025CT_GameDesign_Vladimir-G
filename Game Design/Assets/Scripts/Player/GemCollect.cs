using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    public GemController gc;

    public float waitAfterGemTime = 0.5f;

    void Update()
    {
        if (waitAfterGemTime > 0)
        {
            waitAfterGemTime -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem") && waitAfterGemTime <= 0)
        {
            Destroy(other.gameObject);
            gc.gemCount++;
            waitAfterGemTime = 0.5f;
        }
    }
}
