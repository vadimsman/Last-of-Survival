using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayConroller : MonoBehaviour
{
    public float Speed;

    public float DayXRotate;

    public float NightXRotate;

    public GameObject LightGroup;

    private float _newAngleX;

    public bool IsDay;

    public int EnemyCount;
    public int Wave = 0;
    public GameObject WaveUI;
    public float DayDamage;

    public void Start()
    {
        _newAngleX = transform.eulerAngles.x;
    }

    public void Update()
    {
        transform.Rotate(Vector3.right * Speed * Time.deltaTime);
        _newAngleX = transform.eulerAngles.x;
        IsDay = _newAngleX > DayXRotate && _newAngleX < NightXRotate;
        LightOnOrOf();

        if (IsDay == false)
        {
            Wave += 1;
            while (EnemyCount > 0)
            {
                GetComponent<EnemySpawner>().SpawnEnemy();
                EnemyCount -= 1;
            }
            WaveUI.SetActive(true);
        }
        if (IsDay == true)
        {
            GetComponent<EnemyHealth>().DayDamage(DayDamage);
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
