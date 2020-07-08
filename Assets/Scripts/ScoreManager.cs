using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text highScoreText;
    public Text jewelText;

    public float scoreCount;
    public float highScoreCount;
    public int jewelCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    void Start () {
        if (PlayerPrefs.HasKey ("HighScore") != null) {
            highScoreCount = PlayerPrefs.GetFloat ("HighScore");
        }
    }

    void Update () {

        if (scoreIncreasing) {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount) {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat ("HighScore", highScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round (scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round (highScoreCount);
        jewelText.text = "" + jewelCount;

    }

    public void AddScore (int pointsToAdd) {
        scoreCount += pointsToAdd;
        jewelCount++;

    }
}