using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public float Damage;
    public Camera CameraLink;
    public float KeyDown;
    public float KeyDownSpeed;
    public int Ammo;
    public int MaxAmmo;
    public int AmmoInInventory;
    public float ReloadTime;

    private int NeedAmmo;
    private float _currentReloadTime;

    public void Update()
    {
        KeyDown -= KeyDownSpeed;
        if (KeyDown < 0)
        {
            KeyDown = 0;
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = CameraLink.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (KeyDown == 0 && Ammo != 0)
                {
                    Ammo -= 1;
                    if (hit.collider.gameObject.GetComponent<EnemyHealth>() != null)
                    {
                        GetComponent<EnemyHealth>().Damage(Damage);
                    }
                    KeyDown = 1;
                }
            }
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
        }
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }
    }

    private void Reload()
    {
        NeedAmmo = MaxAmmo - Ammo;
        AmmoInInventory -= NeedAmmo;

        Ammo = MaxAmmo;
        _currentReloadTime = ReloadTime;
    }
}
