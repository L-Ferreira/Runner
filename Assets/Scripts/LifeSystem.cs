using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public GameObject[] hearts;
    public float life;
    public bool dead;
    private AudioSource damageSound;
    private PlayerController thePlayerController;
    private SpriteRenderer playerSprite;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    private Animator myAnimator;

    [SerializeField]
    public GameObject heartHalf;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();

        thePlayerController = FindObjectOfType<PlayerController>();
        damageSound = GameObject.Find("DamageSound").GetComponent<AudioSource>();
        life = hearts.Length;

    }

    private void Update()
    {
        if (dead == true)
        {
            thePlayerController.KillPlayer();
        }

        if (flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }

        myAnimator.SetBool("Dead", dead);

    }

    public void TakeDamage(float damage)
    {
        if (life >= 1)
        {
            life -= damage;

            flashActive = true;
            flashCounter = flashLength;

            int index = Mathf.CeilToInt(life - 1 < 0 ? 0 : life - 1);
            print(life + " - " + index);

            hearts[index].gameObject.SetActive(false);

            if (damage == 0.5f)
            {
                hearts.SetValue(heartHalf, index);
                hearts[index].gameObject.SetActive(true);
            }
            //Destroy (hearts[life].gameObject);
            damageSound.Play();
            if (life < 1)
            {
                dead = true;
            }
        }
    }

    public void AddLife(int lifesToAdd)
    {
        if (life < 5)
        {
            life += lifesToAdd;
            hearts[Mathf.CeilToInt(life) - 1].gameObject.SetActive(true);
        }


    }
}