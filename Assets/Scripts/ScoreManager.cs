using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public Text jewelText;

    public float scoreCount;
    public float highScoreCount;
    public int jewelCount;

    public int totalJewelCount;
    public int prefsJewelCount;


    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore") != null)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("TotalJewels") != null)
        {
            prefsJewelCount = PlayerPrefs.GetInt("TotalJewels");
        }
    }

    void Update()
    {

        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "Best: " + Mathf.Round(highScoreCount);
        jewelText.text = "" + jewelCount;

    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
        jewelCount++;
        totalJewelCount++;

    }

    public void KillEnemyAddScore(int score)
    {
        scoreCount += score;
    }
}