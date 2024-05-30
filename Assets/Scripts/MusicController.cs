using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public int counter = 0;
    public GameObject DayController;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    void Start()
    {

    }

    void Update()
    {
        if(DayController.GetComponent<Transform>().rotation.x > 200)
        {
            counter += 1;

            if(counter == 1)
            {
                audioSource.Play();
            }

            if(counter == 2)
            {
                audioSource.Stop();
                audioSource2.Play();
            }

            if(counter == 3)
            {
                audioSource2.Stop();
                audioSource3.Play(); 
            }

            if(counter == 4)
            {
                audioSource3.Stop();
                audioSource4.Play(); 
            }

            if(counter == 5)
            {
                audioSource4.Stop();
                audioSource5.Play(); 
            }
        }
    }
}
