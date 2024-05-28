using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject DefeatUI;
    public PlayerHealth PlayerHealth;
    public void Update()
    {
        if(PlayerHealth.Value <= 0)
        {
            DefeatUI.SetActive(true);
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
