using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    public Text highScoreText;
    public Text jewelText;

    public string tutorialMenu;


    public float highScoreCount;
    public int totalJewels;

    public string playGameLevel;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("TotalJewels") != null)
        {
            totalJewels = PlayerPrefs.GetInt("TotalJewels");
        }
    }

    public void PlayGame()
    {
        Application.LoadLevel(playGameLevel);
    }

    public void Tutorial()
    {
        Application.LoadLevel(tutorialMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        highScoreText.text = "Best Score: " + Mathf.Round(highScoreCount);
        jewelText.text = "Total Jewels: " + totalJewels;
    }
}