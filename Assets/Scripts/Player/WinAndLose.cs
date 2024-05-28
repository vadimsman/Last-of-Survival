using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject DefeatUI;
    public GameObject GamePlayUI;
    public PlayerHealth PlayerHealth;
    public bool IsWin;
    public void Update()
    {
        if(PlayerHealth.Value <= 0)
        {
            DefeatUI.SetActive(true);
            GamePlayUI.SetActive(false);
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (IsWin)
        {
            WinUI.SetActive(true);
            GamePlayUI.SetActive(false);
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
