using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManuManager : MonoBehaviour {

    public GameObject startChooseCanvas;
    public GameObject settingCanvas;

    public void OnStartButton()
    {
        startChooseCanvas.SetActive(true);
    }

    public void OnSettingButton()
    {
        settingCanvas.SetActive(true);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnOnePlayerButton()
    {

    }

    public void OnTwoPlayerButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSettingExitButton()
    {
        settingCanvas.SetActive(false);
    }
}
