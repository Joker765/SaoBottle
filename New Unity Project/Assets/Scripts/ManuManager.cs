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
        PlayerPrefs.SetInt("onePlayer", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void OnTwoPlayerButton()
    {
        PlayerPrefs.SetInt("onePlayer", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void OnSettingExitButton()
    {
        settingCanvas.SetActive(false);
    }
}
