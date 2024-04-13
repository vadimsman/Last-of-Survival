using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider VolumeSlider;
    public void VolumeСhange()
    {
        GetComponent<Settings>().Volume = VolumeSlider.value;
    }
}
