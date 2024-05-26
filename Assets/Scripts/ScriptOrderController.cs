using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOrderController : MonoBehaviour
{
    private EnemyAI _mob;
    private EnemyGatesEvent _gatesEvent;
    private GatesHealth _gatesHealth;

    private void Start()
    {
        LinksComponents();

        if (_gatesHealth != null)
        {
            _gatesEvent.enabled = true;
        }
        else
        {
            _mob.enabled = true;
        }

        
    }

    private void Update()
    {
        if (_gatesHealth == null)
        {
            _gatesEvent.enabled = false;
            _mob.enabled = true;
        }
        else
        {
            _gatesEvent.enabled = true;
            _mob.enabled = false;
        }
        
        
    }

    private void LinksComponents()
    {
        _mob = GetComponent<EnemyAI>();
        _gatesEvent = GetComponent<EnemyGatesEvent>();
        _gatesHealth = FindObjectOfType<GatesHealth>();
    }
}
