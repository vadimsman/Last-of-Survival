using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayConroller : MonoBehaviour
{
    public Transform DirectionLight;

    public float Speed;

    public float DayXRotate;

    public float NightXRotate;

    public bool DayOrNight; //День это true, ночь это false

    public GameObject LightGroup;

    private float _newAngleX;

    public void Start()
    {
        
    }

    public void Update()
    {
        DirectionLight.transform.Rotate(Vector3.right * Speed * Time.deltaTime);
        DayUpdate();
    }

    public void DayUpdate()
    {
        if(_newAngleX <= NightXRotate)
        {
            LightGroup.SetActive(true);
            DayOrNight = false;
        }

        if(_newAngleX <= DayXRotate)
        {
            LightGroup.SetActive(false);
            _newAngleX = 50;
            DayOrNight = true;
        }
    }
}
