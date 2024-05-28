using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float value;

    public Slider Slider;

    public float Value => value;

    public void Update()
    {
        Slider.value = value;
    }
    public void DealDamage(float amount)
    {
        value -= amount;
    }
}
