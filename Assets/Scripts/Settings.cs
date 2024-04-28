using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public int Quality;
    public GameObject SettingsUI;
    public GameObject MenuUI;

    public void setQuality(int index)
    {
        Quality = index;
    }

    public void confirmSettings()
    {
        QualitySettings.SetQualityLevel(Quality, true);
        SettingsUI.SetActive(false);
        MenuUI.SetActive(true);
    }
}
