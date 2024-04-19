using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    public float BasicWeaponDamage;
    public GameObject EnemyPrefabs;
    public List<GameObject> unityGameObjects = new List<GameObject>();

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
