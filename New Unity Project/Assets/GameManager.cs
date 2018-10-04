using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverCanvas;
    public GameObject pauseCanvas;
    public Text gameOverText;
    public static GameManager Instance;
    public Transform bornPos;
    public GameObject blueO;
    public GameObject blueA;
    
    private AudioSource confidence;
    private bool close;

    private void Awake()
    {
        Time.timeScale = 1;
        close = false;
        Instance = this;
        confidence = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("music") == 0) confidence.enabled = false;
        else
        {
            confidence.enabled = true;
            confidence.volume = PlayerPrefs.GetFloat("volume");
        }

        if (PlayerPrefs.GetInt("onePlayer") == 1)
        {
            GameObject.Instantiate(blueA, bornPos.position,bornPos.rotation);
        }
        else GameObject.Instantiate(blueO, bornPos.position, bornPos.rotation);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !close)
            {
                close = true;
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
            }
    }

    public void GameOver(bool redWin)
    {
        gameOverCanvas.SetActive(true);
        if (redWin)
        {
            gameOverText.text = "Red Win !";
            gameOverText.color = Color.red;
        }
        else {
            gameOverText.text = "Blue Win !";
            gameOverText.color = Color.blue;
        }
    }

    public void Tie()
    {
        gameOverCanvas.SetActive(true);
        gameOverText.text = "TIE !";
    }

    public void OnReStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnContinueButton()
    {
        close = false;
        Time.timeScale = 1; 
        pauseCanvas.SetActive(false);      
    }

    public void OnPauseButton()
    {
        close = true;
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }

}
