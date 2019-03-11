﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;
    public GameObject gameOverPanel;
    public GameObject startUi;
    public GameObject gameOverText;
    public Text scoreText;
    public Text highScoreText;
    

    private void Awake()
    {
       if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //scoreText is updated by calling "score" variable from ScoreManager
        scoreText.text = ScoreManager.instance.score.ToString();
	}

    public void GameStart()
    {
        //startUi is deactivated when game starts
        startUi.SetActive(false);

    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        gameOverPanel.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("level1");
        AdManager.instance.hideBanner();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }


}
