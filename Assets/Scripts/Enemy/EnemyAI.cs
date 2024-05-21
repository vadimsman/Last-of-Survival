﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _mob;
    public List<Transform> Point;
    private EnemyGatesEvent _enemyGatesEvent;

    public PlayerController Player;
    private bool _playerVisibility;

    private void Start()
    {
        LinksGetComponents();
        RandomPatrolPoints();
        _enemyGatesEvent.enabled = false;
    }

    private void Update()
    {
        CheckingDistancePoints();
        
        CharacterVisiblyCheck();
        
        PatrolToPlayer();
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
        if (!_playerVisibility)
        {
            if (_mob.remainingDistance <= _mob.stoppingDistance)
            {
                RandomPatrolPoints();
            }
        }
    }
    private void PatrolToPlayer()
    {
        if (_playerVisibility)
        {
            _mob.destination = Player.transform.position;
        }
    }
    private void CharacterVisiblyCheck()
    {
        _playerVisibility = false;
        
        var direction = Player.transform.position - transform.position;
        RaycastHit hit;

        Ray ray = new Ray(transform.position + Vector3.up, direction);
        
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == Player.gameObject)
            {
                _playerVisibility = true;
            }
        }
    }
}