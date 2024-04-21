using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject ButtonUI;
    public GameObject TiterUI;
    public GameObject GamePlayUI;
    public GameObject PauseUI;
    public GameObject SettingsUI;
    public GameObject SettingsFullUI;
    public Sprite SoundsOnSprite;
    public Sprite SoundOffSprite;
    public Button SoundButton;
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
        Time.timeScale = 1;
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

    public void GoSettings()
    {
        SettingsFullUI.SetActive(true);
        ButtonUI.SetActive(false);
    }

    public void ExitSettings()
    {
        SettingsFullUI.SetActive(false);
        ButtonUI.SetActive(true);
    }

    public void SetSensitivity(float LocalSensitivity)
    {
        PlayerPrefs.SetFloat("Sensitivity", LocalSensitivity);
    }

    public void SaveSettings()
    {
        GetComponent<CameraRotation>().RotationSpeed = PlayerPrefs.GetFloat("Sensitivity");
        SettingsFullUI.SetActive(false);
        ButtonUI.SetActive(true);
    }

    public void SoundToggleButton()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            SoundButton.image.sprite = SoundsOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            SoundButton.image.sprite = SoundOffSprite;
        }
    }
}
