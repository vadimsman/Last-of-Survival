using UnityEngine;
using UnityEngine.AI;

public class EnemyGatesEvent : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _mob;

    [SerializeField] private GatesHealth _gatesHealth;

    [SerializeField] private float _amount = 10;

    private EnemyAI _mobPatrol;

    private void Start()
    {
        LinkGetComponents();
    }
    private void Update()
    {
        GateDetectionAndDamage();
    }

    private void GateDetectionAndDamage()
    {
        _mob.destination = _gatesHealth.transform.position;
        if (_mob.remainingDistance <= _mob.stoppingDistance)
        {
            _gatesHealth.DealDamage(_amount * Time.deltaTime);
        }
    }

    private void LinkGetComponents()
    {
        _mob = GetComponent<NavMeshAgent>();
        _mobPatrol = GetComponent<EnemyAI>();
        _gatesHealth = FindObjectOfType<GatesHealth>();
    }
}
