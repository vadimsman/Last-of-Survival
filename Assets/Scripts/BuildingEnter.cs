using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingEnter : MonoBehaviour
{
    public string NameScene;
    public GameObject EnterUI;
    public GameObject GamePlayUI;

    private bool _isEnterUIOpen;

    public void Update()
    {
        if (_isEnterUIOpen == true && Input.GetKeyDown(KeyCode.F))
        {
            GoToScene();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other = GetComponent<CharacterController>())
        {
            EnterUI.SetActive(true);
            GamePlayUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isEnterUIOpen = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other = GetComponent<CharacterController>())
        {
            EnterUI.SetActive(false);
            GamePlayUI.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isEnterUIOpen = false;
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(NameScene);
    }
}
