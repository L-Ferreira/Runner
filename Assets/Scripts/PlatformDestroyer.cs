using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject platformDestructionPoint;

    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            // Destroy (gameObject);
            print(gameObject.tag);
            if (gameObject.GetComponent<Enemy>() || gameObject.GetComponent<EnemySpawner>() || gameObject.tag == "fireball")
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}