using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public float BasicWeaponDamage;
    public Camera CameraLink;
    public GameObject EnemyPrefabs;
    public List<GameObject> unityGameObjects = new List<GameObject>();

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = CameraLink.ViewportPointToRay(new Vector3(0, 0, 0));

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                
            }
        }
    }
}
