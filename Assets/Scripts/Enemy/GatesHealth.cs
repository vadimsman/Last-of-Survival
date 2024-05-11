using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatesHealth : MonoBehaviour
{ 
    public float _value = 100;
    public bool isGatesDestroy;

    public void DealDamage(float amount)
    {
        isGatesDestroy = false;
        _value -= amount;

        if (_value <= 0)
        {
            Destroy(gameObject);
            isGatesDestroy = true;
        }
    }
}
 