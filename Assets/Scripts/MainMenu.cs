using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string playGameLevel;

    public void PlayGame () {
        Application.LoadLevel (playGameLevel);
    }

    public void QuitGame () {
        Application.Quit ();
    }
}