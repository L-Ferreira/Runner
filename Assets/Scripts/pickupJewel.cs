using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupJewel : MonoBehaviour {

    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource jewelSound;

    void Start () {
        theScoreManager = FindObjectOfType<ScoreManager> ();

        jewelSound = GameObject.Find ("JewelSound").GetComponent<AudioSource> ();
    }

    void Update () {

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.name == "Player") {
            theScoreManager.AddScore (scoreToGive);

            gameObject.SetActive (false);

            if (jewelSound.isPlaying) {
                jewelSound.Stop ();
                jewelSound.Play ();
            } else {
                jewelSound.Play ();
            }
        }
    }
}