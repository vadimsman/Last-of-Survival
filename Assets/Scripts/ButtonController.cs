using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ButtonUI;
    public GameObject TiterUI;
    private void Start()
    {
        TiterUI.SetActive(false);
    }
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
}
