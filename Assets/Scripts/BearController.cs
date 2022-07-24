using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    private Health playerHealth;
    private Health bearHealth;
    private Vector3 originalPosition;
    private Transform playerPosition;
    private Animator bearAnimator;
    private bool playerLeft;
    float lastAttackTime;
    
    [Header("Bear Attributes")]
    public float attackCoolDown = 3f;
    public float speed = 1f;

    [Header("Player")]
    public GameObject player;

    private AudioSource bearAudio;
    private void Start()
    {
        originalPosition = GetComponent<Transform>().position;
        bearAnimator = GetComponent<Animator>();
        playerHealth = player.GetComponent<Health>();
        bearHealth = gameObject.GetComponent<Health>();
        bearAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        lastAttackTime -= Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Dead();
        flipBear();

        if (playerLeft == true)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, originalPosition, speed * Time.deltaTime);
        }
        else if(playerPosition != null)
        {
            bearAnimator.SetBool("isFollowing", true);
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, playerPosition.position, speed * Time.deltaTime);
        }

        if (gameObject.transform.position == originalPosition)
        {
            bearAnimator.SetBool("isFollowing", false);
        }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerPosition = collision.transform;
            playerLeft = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerLeft = true;
        }
    }

    private void flipBear()
    {
        if(playerPosition != null)
        {
            if (gameObject.transform.position.x <= playerPosition.position.x)
            {
                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 180, gameObject.transform.eulerAngles.z);
            }
            else
            {
                gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 0, gameObject.transform.eulerAngles.z);
            }
        }
       
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && lastAttackTime < 0)
        {
            lastAttackTime = attackCoolDown;
            Attack();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bearAnimator.SetBool("isAttacking", false);
        }
    }

    private void Attack()
    {
        bearAnimator.SetBool("isAttacking", true);
    }

    public void Hit()
    {
        playerHealth.currentHealth -= 1;
        bearAudio.Play();
    }

    private void Dead()
    {
        if(bearHealth.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
