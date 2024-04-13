using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ButtonUI;
    public GameObject TiterUI;
    public GameObject GamePlayUI;
    public GameObject PauseUI;
    public GameObject SettingsUI;
    public void PlayButton(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Titer()
    {
        ButtonUI.SetActive(false);
        TiterUI.SetActive(true);
    }

    public void ExitTiter()
    {
        ButtonUI.SetActive(true);
        TiterUI.SetActive(false);
    }

    public void GoMainMenu(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Continue()
    {
        PauseUI.SetActive(false);
        GamePlayUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SettingsInGame()
    {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
        GetComponent<PlayerController>().IsSettingsOpen = true;
    }

    public void ExitSettingsInGame()
    {
        SettingsUI.SetActive(false);
        PauseUI.SetActive(true);
        GetComponent<PlayerController>().IsSettingsOpen = false;
    }
}
