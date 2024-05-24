using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value;
    public float Damage;
    public UnityEngine.GameObject EnemyParent;
    
    public void DamageUpdate()
    {
        value -= Damage;
        Death();
    }

    public void DayDamage(float Damage)
    {
        value -= Damage;
    }

    public void Death()
    {
        if (value <= 0)
        {
            Destroy(EnemyParent);
        }
    }
}
