using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupLife : MonoBehaviour
{
    public int lifeToGive;

    private LifeSystem theLifeSystem;

    private AudioSource lifeSound;

    void Start()
    {
        theLifeSystem = FindObjectOfType<LifeSystem>();

        lifeSound = GameObject.Find("LifeSound").GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            theLifeSystem.AddLife(lifeToGive);

            gameObject.SetActive(false);

            lifeSound.Play();

        }
    }
}
