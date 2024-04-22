using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _mob;
    public List<Transform> Point;
    private EnemyGatesEvent _enemyGatesEvent;

    private void Start()
    {
        LinksGetComponents();
        RandomPatrolPoints();
        _enemyGatesEvent.enabled = false;
    }

    private void Update()
    {
        CheckingDistancePoints();
    }

    private void LinksGetComponents()
    {
        _mob = GetComponent<NavMeshAgent>();
        _enemyGatesEvent = GetComponent<EnemyGatesEvent>();
    }

    private void RandomPatrolPoints()
    {
        _mob.destination = Point[Random.Range(0, Point.Count)].position;
    }

    private void CheckingDistancePoints()
    {
        if (_mob.remainingDistance < _mob.stoppingDistance)
        {
            RandomPatrolPoints();
        }
    }
}
