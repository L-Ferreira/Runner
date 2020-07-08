using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelGenerator : MonoBehaviour {

    public ObjectPooler jewelPool;

    public float distanceBetweenJewels;

    public void SpawnJewels (Vector3 startPosition) {
        GameObject jewel1 = jewelPool.GetPooledObject ();
        jewel1.transform.position = startPosition;
        jewel1.SetActive (true);

        GameObject jewel2 = jewelPool.GetPooledObject ();
        jewel2.transform.position = new Vector3 (startPosition.x - distanceBetweenJewels, startPosition.y, startPosition.z);
        jewel2.SetActive (true);

        GameObject jewel3 = jewelPool.GetPooledObject ();
        jewel3.transform.position = new Vector3 (startPosition.x + distanceBetweenJewels, startPosition.y, startPosition.z);
        jewel3.SetActive (true);
    }
}