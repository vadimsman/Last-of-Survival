using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _mob;
    [SerializeField] private List<Transform> _point;

    private void Start()
    {
        _mob = GetComponent<NavMeshAgent>();
        _mob.destination = _point[Random.Range(0, _point.Count)].position;
    }

    private void Update()
    {
        if (_mob.remainingDistance == 0)
        {
            _mob.destination = _point[Random.Range(0, _point.Count)].position;
        }
    }
}
