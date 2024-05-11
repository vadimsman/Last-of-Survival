using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float value;
    public float Damage;
    
    public void DamageUpdate()
    {
        value -= Damage;
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
