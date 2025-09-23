using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;



public class LightFlicker : MonoBehaviour
{
    public float flickerIntesity = 2.5f;
    public float flickersPerSecond = 3.0f;
    public float speedRandomness = 1.0f;

    private float time;
    private float startingIntesity;
    private Light2D light2D;


    void Start()
    {
        light2D = GetComponent<Light2D>();
        startingIntesity = light2D.intensity;

    }

    void Update()
    {
        float jitter = Random.Range(-speedRandomness, speedRandomness);
        float randomFactor = 1f - jitter;
        time += Time.deltaTime * randomFactor * Mathf.PI;
        light2D.intensity = startingIntesity + Mathf.Sin(time * flickersPerSecond) * flickerIntesity;
    }
}

