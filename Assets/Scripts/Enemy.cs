using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundLayerMask;

    private Collider2D[] results = new Collider2D[1];

    [SerializeField]
    private float speed = 1f;

    private bool isShotting = false;

    private Camera mainCamera;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private GameObject fireballPrefab;

    public PlayerController player;

    private float shootVelocity = 3f;

    private ScoreManager theScoreManager;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mainCamera = FindObjectOfType<Camera>();
        player = FindObjectOfType<PlayerController>();

    }

    private void Start()
    {

        int index = SpriteRenderingOrderManager.Instance.GetEnemyOrderInLayer();
        GetComponent<SpriteRenderer>().sortingOrder = index;
    }

    private void Update()
    {
        myRigidbody.velocity = new Vector2(-speed * transform.right.x, myRigidbody.velocity.y);

        if (player != null)
        {
            if (myRigidbody.position.y - 0.5 <= player.transform.position.y &&
                myRigidbody.position.y + 0.5 >= player.transform.position.y &&
                myRigidbody.position.x - 9 <= player.transform.position.x &&
                myRigidbody.position.x + 9 >= player.transform.position.x)
            {
                EnemyShoot();
            }
        }



    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapPointNonAlloc(groundCheck.position, results, groundLayerMask) == 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.y += 180f;
        transform.localEulerAngles = localRotation;
    }

    private void DestroyEnemy() //called by animation event
    {
        Destroy(gameObject);
    }

    private void EnemyShoot()
    {
        if (!isShotting)
        {
            isShotting = true;
            myAnimator.SetTrigger("EnemyAttack");
        }
    }

    private void AnimatorEventEnemyShoot()
    {
        if (player != null)
        {
            if ((myRigidbody.position.x > player.transform.position.x && transform.rotation.y >= 0)
                || (myRigidbody.position.x < player.transform.position.x && transform.rotation.y < 0))
            {
                Flip();
            }
            GameObject fireball = Instantiate(fireballPrefab, shootPoint.position, shootPoint.rotation);
            fireball.GetComponent<Rigidbody2D>().velocity = shootPoint.right * shootVelocity;
        }
    }

    private void EnemyStopShoot()
    {
        isShotting = false;
    }

    public void Dismiss()
    {
        Destroy(gameObject);
    }
}