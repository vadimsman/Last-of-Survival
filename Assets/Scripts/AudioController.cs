using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource ShootSound;
    public AudioSource ReloadSound;

    public void ShootSoundPlay()
    {
        ShootSound.Play();
    }

    public void ReloadSoundPlay()
    {
        ReloadSound.Play();
    }
}
