using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayConroller : MonoBehaviour
{
    public float Speed;

    public float DayXRotate;

    public float NightXRotate;

    public UnityEngine.GameObject LightGroup;

    private float _newAngleX;

    public bool IsDay;

    public int EnemyCount;
    public int Wave = 0;
    public UnityEngine.GameObject WaveUI;
    public float DayDamage;

    private EnemyHealth _enemyHealth;

    public void Start()
    {
        _newAngleX = transform.eulerAngles.x;
        _enemyHealth = FindObjectOfType<EnemyHealth>();

    }

    public void Update()
    {
        transform.Rotate(Vector3.right * Speed * Time.deltaTime);
        _newAngleX = transform.eulerAngles.x;
        IsDay = _newAngleX > DayXRotate && _newAngleX < NightXRotate;
        LightOnOrOf();
        
        if (IsDay == true)
        {
           _enemyHealth.DayDamage(DayDamage);
        }
    }

    private void LightOnOrOf()
    {
        if (IsDay)
        {
            LightGroup.SetActive(false);
        }
        if (!IsDay)
        {
            LightGroup.SetActive(enabled);
        }
    }
}
