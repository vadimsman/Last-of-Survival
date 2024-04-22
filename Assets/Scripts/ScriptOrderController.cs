using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOrderController : MonoBehaviour
{
    private EnemyAI _mob;
    private EnemyGatesEvent _gatesEvent;

    private void Start()
    {
        _mob = GetComponent<EnemyAI>();
        _gatesEvent = GetComponent<EnemyGatesEvent>();

        _mob.enabled = false;
        _gatesEvent.enabled = true;
    }
}
