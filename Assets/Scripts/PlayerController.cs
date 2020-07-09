using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool stoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    public LifeSystem theLifeSystem;

    void Start () {
        myRigidBody = GetComponent<Rigidbody2D> ();
        //myCollider = GetComponent<Collider2D> ();
        myAnimator = GetComponent<Animator> ();
        theLifeSystem = GetComponent<LifeSystem> ();
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        stoppedJumping = true;

    }

    void Update () {
        grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidBody.velocity = new Vector2 (moveSpeed, myRigidBody.velocity.y);

        if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
                if (EventSystem.current.IsPointerOverGameObject (Input.touches[0].fingerId))
                    return;
            }

            if (grounded) {
                myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
                stoppedJumping = false;
                jumpSound.Play ();
            }

            if (!grounded && canDoubleJump) {
                myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                stoppedJumping = false;
                canDoubleJump = false;
                jumpSound.Play ();

            }
        }

        if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping) {
            if (jumpTimeCounter > 0) {
                myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        if (grounded) {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat ("Speed", myRigidBody.velocity.x);
        myAnimator.SetBool ("Grounded", grounded);

    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "killbox") {
            this.KillPlayer ();
        }

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "spike") {
            theLifeSystem.TakeDamage (1);
        }
    }

    public void RestartPlayer () {
        moveSpeed = moveSpeedStore;
        speedMilestoneCount = speedMilestoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
    }

    public void KillPlayer () {
        theGameManager.RestartGame ();
        moveSpeed = moveSpeedStore;
        speedMilestoneCount = speedMilestoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
        deathSound.Play ();
    }
}