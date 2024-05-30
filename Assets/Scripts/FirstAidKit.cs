using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public int ValueHealth;
    public void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            PlayerHealth.AddHealth(ValueHealth);
            Destroy(gameObject);
        }
    }
}
