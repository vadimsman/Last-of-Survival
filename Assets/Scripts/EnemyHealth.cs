using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value;
    
    public void Damage(float DamageValue)
    {
        value -= DamageValue;
        Death();
    }

    public void Death()
    {
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
