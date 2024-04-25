using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Debug.Log(QualitySettings.names);
            QualitySettings.SetQualityLevel(0, false);
            QualitySettings.SetQualityLevel(4, true);
        }
    }
}
