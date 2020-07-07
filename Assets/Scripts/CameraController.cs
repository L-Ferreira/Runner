using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition;
    private Vector3 targetPosition;
    private Vector3 cameraVelocity;
    private float distanceToMove;
    private float smoothTime = 0.0001f;

    void Awake () {
        thePlayer = FindObjectOfType<PlayerController> ();
        lastPlayerPosition = thePlayer.transform.position;
    }

    void LateUpdate () {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

        targetPosition = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp (transform.position, targetPosition, ref cameraVelocity, smoothTime);

        lastPlayerPosition = thePlayer.transform.position;
    }
}