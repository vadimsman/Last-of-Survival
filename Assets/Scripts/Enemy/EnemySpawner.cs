using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform SpawnerPoints;
    public EnemyAI EnemyPrefab;

    private List<EnemyAI> _enemies;
    public int MaxCountEnemy;
    public float SpawnDelay;
    
    private DayConroller _dayConroller;

    private float _lastTimeSpawn;
    

    public List<Transform> Points;

    private void Start()
    {
        _dayConroller = FindObjectOfType<DayConroller>();
        _enemies = new List<EnemyAI>();
    }

    private void Update()
    {
        if(_enemies.Count >= MaxCountEnemy) return;
        if(_dayConroller.IsDay) return;
        if(IsInvoking()) return;
        Invoke("CreateEnemy", SpawnDelay);
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(EnemyPrefab);
        enemy.transform.position = SpawnerPoints.position;
        enemy.Point = Points;
        _enemies.Add(enemy);
    }
}
