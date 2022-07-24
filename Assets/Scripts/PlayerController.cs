using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("User Interfaces and GameGrid")]
    public Text woodText;
    public GameObject cowCommentary;
    public GameObject pauseScreen;
    public GameObject lostMenu;
    public GameObject gameGrid;

    [Header("Enemy Bear")]
    public GameObject bear;

    private Health bearHealth;
    private Health playerHealth;
    private PlayerInput input;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector2 movement;
    private static int woodCount = 0;

    [Header("Player Speed")]
    public float speed = 5f;
    [Header("Sounds")]
    public GameObject axe;
    public GameObject wood;

    private AudioSource axeSound;
    private AudioSource playerSound;
    private AudioSource backgroundMusic;
    private AudioSource woodSounds;

    private void Awake()
    {
        input = new PlayerInput();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bearHealth = bear.GetComponent<Health>();
        playerHealth = gameObject.GetComponent<Health>();
        playerSound = gameObject.GetComponent<AudioSource>();
        backgroundMusic = gameGrid.GetComponent<AudioSource>();
        axeSound = axe.GetComponent<AudioSource>();
        woodSounds = wood.GetComponent<AudioSource>();
    }

    private void Update()
    {
        PauseGame();
        Dead();
        FightBear();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        if(lostMenu.activeSelf == false)
        {
            movement = input.Player.Movement.ReadValue<Vector2>();
            rigidBody.velocity = movement * speed;
        }
        
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void AnimatePlayer()
    {
        animator.SetFloat("Horizontal", input.Player.Movement.ReadValue<Vector2>().x);
        animator.SetFloat("Vertical", input.Player.Movement.ReadValue<Vector2>().y);
        animator.SetFloat("Speed", rigidBody.velocity.magnitude);
        if(rigidBody.velocity.x != 0 || rigidBody.velocity.y != 0)
        {
            if (!playerSound.isPlaying)
            {
                playerSound.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wood")
        {
            woodCount++;
            woodText.text = woodCount.ToString();
            woodSounds.Play();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Cow")
        {
            cowCommentary.SetActive(true);
            collision.gameObject.tag = "Done";
        }
    }

    private void FightBear()
    {
        if (input.Player.Select.triggered && Vector2.Distance(gameObject.transform.position, bear.transform.position) < 2)
        {
            animator.SetTrigger("Fight");
        }
    }

    public void Hit()
    {
        bearHealth.currentHealth -= 1;
        axeSound.Play();
    }

    private void Dead()
    {
        if(playerHealth.currentHealth <= 0)
        {
            Time.timeScale = 0;
            backgroundMusic.Stop();
            playerSound.Stop();
            lostMenu.SetActive(true);
        }
    }

    public void PauseGame()
    {
        if (input.Player.Pause.triggered)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
    }
}
