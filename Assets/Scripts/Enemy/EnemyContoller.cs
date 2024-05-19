using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public int EnemyCount;
    public int Wave = 0;
    public GameObject WaveUI;
    public float DayDamage;

    public void Update()
    {
        var IsDay = GetComponent<DayConroller>().IsDay;
        if (IsDay == false)
        {
            Wave += 1;
            while(EnemyCount > 0)
            {
                GetComponent<EnemySpawner>().SpawnEnemy();
            }
            WaveUI.SetActive(true);
        }
        if (IsDay == true)
        {
            GetComponent<EnemyHealth>().DayDamage(DayDamage);
        }
    }
}
