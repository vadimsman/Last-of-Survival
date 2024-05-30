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
    private EnemySpawner _enemySpawner;
    private DayConroller _dayController;

    public void Start()
    {
        _dayController = FindObjectOfType<DayConroller>();
        _enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    public void Update()
    {
        if(PlayerHealth.Value <= 0)
        {
            DefeatUI.SetActive(true);
            GamePlayUI.SetActive(false);
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Escape))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (_dayController.DayCount == 5 && _enemySpawner._enemies.Count == 0)
        {
            WinUI.SetActive(true);
            GamePlayUI.SetActive(false);
            Time.timeScale = 1;
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
