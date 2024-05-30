using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAdd : MonoBehaviour
{
    public int AmmoCount;
    public void OnTriggerEnter(Collider other)
    {
        var ShootingScript = other.gameObject.GetComponent<ShootingScript>();
        if (ShootingScript != null)
        {
            ShootingScript.AddAmmo(AmmoCount);
            Destroy(gameObject);
        }
    }
}
