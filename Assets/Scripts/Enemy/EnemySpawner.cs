using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform EnemySpawnerObject;
    public EnemyAI EnemyPrefab;
    public PlayerController PlayerController;
    public List<Transform> PatrolPoint;

    public void SpawnEnemy()
    {
        var enemy = Instantiate(EnemyPrefab, EnemySpawnerObject.position, EnemySpawnerObject.rotation);
        enemy.SetUpEnemy(PlayerController, PatrolPoint);
    }
}
