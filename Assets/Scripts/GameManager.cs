using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;
    private LifeSystem theLifeSystem;

    public DeathMenu theDeathScreen;
    public GameObject pauseButton;

    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
        theScoreManager.scoreIncreasing = true;

        theLifeSystem = FindObjectOfType<LifeSystem>();
    }

    void Update()
    {

    }

    public void RestartGame()
    {

        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

        if (theScoreManager.totalJewelCount > 0)
        {
            theScoreManager.totalJewelCount += theScoreManager.prefsJewelCount;
            PlayerPrefs.SetInt("TotalJewels", theScoreManager.totalJewelCount);
        }

        //StartCoroutine ("RestartGameCo");
        theDeathScreen.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void Reset()
    {

        theDeathScreen.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);

        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.jewelCount = 0;
        theScoreManager.scoreIncreasing = true;

        for (int i = 0; i < theLifeSystem.hearts.Length; i++)
        {
            theLifeSystem.hearts[i].gameObject.SetActive(true);
        }
        theLifeSystem.life = theLifeSystem.hearts.Length;
        theLifeSystem.dead = false;

    }

    // public IEnumerator RestartGameCo () {

    //     yield return new WaitForSeconds (0.5f);

    // }
}