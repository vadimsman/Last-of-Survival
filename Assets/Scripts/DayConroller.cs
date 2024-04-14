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

    public void Update()
    {
        _newAngleX = DirectionLight.localEulerAngles.x - Time.deltaTime * Speed * 1;
        DirectionLight.localEulerAngles = new Vector3(_newAngleX, 0, 0);
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
