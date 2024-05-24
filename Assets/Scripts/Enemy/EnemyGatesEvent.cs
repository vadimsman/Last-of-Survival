using System.Collections.Generic;
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
        // Перебираем все объекты в сцене
        foreach (var obj in FindObjectsOfType<GameObject>())
        {
            // Проверяем, содержит ли объект компонент ExampleScriptNeeded
            if (obj.GetComponent<GatesHealth>() != null)
            {
                // Сохраняем ссылку на нужный скрипт
                _gatesHealth = obj.GetComponent<GatesHealth>();
                break; // Прерываем цикл, так как нашли нужный объект
            }
        }
    }
    private void Update()
    {
        GateDetectionAndDamage();
        EnablingTheMainScript();
    }

    private void GateDetectionAndDamage()
    {
        _mob.destination = _gatesHealth.transform.position;
        if (_mob.remainingDistance <= _mob.stoppingDistance)
        {
            _gatesHealth.DealDamage(_amount * Time.deltaTime);
        }
    }

    private void EnablingTheMainScript()
    {
        if (_gatesHealth.isGatesDestroy)
        {
            _mobPatrol.enabled = true;
        }
    }

    private void LinkGetComponents()
    {
        _mob = GetComponent<NavMeshAgent>();
        _mobPatrol = GetComponent<EnemyAI>();
    }
}
