using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private Vector3 initialScale;


    void Awake()
    {
        initialScale = transform.localScale;
    }


    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue - 1;
    }

    void LateUpdate()
    {
        transform.localScale = initialScale;
    }
}
