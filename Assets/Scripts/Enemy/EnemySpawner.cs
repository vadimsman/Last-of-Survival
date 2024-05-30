using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform SpawnerPoints;
    public EnemyAI EnemyPrefab;

    public List<EnemyAI> _enemies;
    public int MaxCountEnemy = 10;
    public float SpawnDelay;
    
    private DayConroller _dayConroller;

    public List<Transform> Points;

    private void Awake()
    {
        _dayConroller = FindObjectOfType<DayConroller>();
    }

    private void Start()
    {
        _enemies = new List<EnemyAI>();
    }

    private void Update()
    {
        if (_dayConroller.IsDay == true)
        {
            MaxCountEnemy = 3;
        }
        if (_enemies.Count == 0)
        {
            _dayConroller.enabled = true;
        }
        if (_enemies.Count == MaxCountEnemy)
        {
            _dayConroller.DayCount += 1;
            _dayConroller.enabled = false;
            MaxCountEnemy = 0;
        }
        for (int i = 0; i < _enemies.Count; i++)
        {
            if(_enemies[i].IsAlive()) continue;
            MaxCountEnemy--;
            _enemies.RemoveAt(i);
            i--;
        }
        
        if(_enemies.Count >= MaxCountEnemy) return;
        if(_dayConroller.IsDay) return;
        if(IsInvoking()) return;
        Invoke("CreateEnemy", SpawnDelay);
    }

    private void CreateEnemy()
    {
        var enemy = Instantiate(EnemyPrefab, SpawnerPoints.position, Quaternion.identity);
        enemy.Point = Points;
        _enemies.Add(enemy);
    }
}
