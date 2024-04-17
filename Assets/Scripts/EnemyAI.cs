using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _mob;
    [SerializeField] private List<Transform> _point;
    
    [SerializeField] private GatesHealth _gatesHealth;

    [SerializeField] private float _amount = 10;

    private void Start()
    {
        _mob = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        var GatesDirection = _gatesHealth.transform.position - transform.position;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, GatesDirection, out hit))
        {
            if (hit.collider.gameObject == _gatesHealth.gameObject)
            {
                _mob.destination = _gatesHealth.transform.position;
                
                if (_mob.remainingDistance < _mob.stoppingDistance)
                {
                    _gatesHealth.DealDamage(_amount * Time.deltaTime);
                }
                
            }
        }

        if (_gatesHealth.isGatesDestroy)
        {
            _mob.destination = _point[Random.Range(0, _point.Count)].position;
            
            if (_mob.remainingDistance < _mob.stoppingDistance && _gatesHealth._value <= 0)
            {
                _mob.destination = _point[Random.Range(0, _point.Count)].position;
            }
        }
        
        

        
    }
    
    
}
