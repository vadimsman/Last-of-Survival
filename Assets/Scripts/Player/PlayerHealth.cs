using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float value;

    public void DealDamage(float amount)
    {
        value -= amount;
        
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
