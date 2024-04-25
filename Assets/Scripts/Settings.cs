using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public int Quality;

    public void setQuality(int _quality)
    {
        Quality = _quality;
    }

    public void confirmSettings()
    {
        QualitySettings.SetQualityLevel(Quality);
    }
}
