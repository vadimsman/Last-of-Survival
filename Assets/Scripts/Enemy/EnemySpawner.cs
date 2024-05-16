using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform EnemySpawnerObject;
    public GameObject EnemyPrefab;

    public void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, EnemySpawnerObject.position, EnemySpawnerObject.rotation);
    }
}
