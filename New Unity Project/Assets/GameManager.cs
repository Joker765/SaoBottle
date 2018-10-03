using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameOverCanvas;
    public Text gameOverText;
    public static GameManager Instance;

    private AudioSource confidence;

    private void Awake()
    {
        Instance = this;
        confidence = GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("music") == 0) confidence.enabled = false;
        else
        {
            confidence.enabled = true;
            confidence.volume = PlayerPrefs.GetFloat("volume");
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

    public void OnBackButton()
    {
        SceneManager.LoadScene(0);
    }

}
