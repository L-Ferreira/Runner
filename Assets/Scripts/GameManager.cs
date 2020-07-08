using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;
    public GameObject pauseButton;

    void Start () {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager> ();
        theScoreManager.scoreIncreasing = true;
    }

    void Update () {

    }

    public void RestartGame () {

        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive (false);

        //StartCoroutine ("RestartGameCo");
        theDeathScreen.gameObject.SetActive (true);
        pauseButton.gameObject.SetActive (false);
    }

    public void Reset () {

        theDeathScreen.gameObject.SetActive (false);
        pauseButton.gameObject.SetActive (true);

        platformList = FindObjectsOfType<PlatformDestroyer> ();
        for (int i = 0; i < platformList.Length; i++) {
            platformList[i].gameObject.SetActive (false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive (true);

        theScoreManager.scoreCount = 0;
        theScoreManager.jewelCount = 0;
        theScoreManager.scoreIncreasing = true;

    }

    // public IEnumerator RestartGameCo () {

    //     yield return new WaitForSeconds (0.5f);

    // }
}