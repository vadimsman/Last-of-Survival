using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float value;

    public bool IsAlive()
    {
        return value > 0;
    }

    public void DamageUpdate(float damage)
    {
        value -= damage;
        DeadEnemy();
    }

    private void DeadEnemy()
    {
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
