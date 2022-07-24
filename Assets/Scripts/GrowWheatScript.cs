using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowWheatScript : MonoBehaviour
{
    public GameObject player;
    public Sprite[] wheatSprites;
    public Text wheatCount;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private static int wheatNum = 0;
    PlayerInput input;

    private void Awake()
    {
        input = new PlayerInput();
    }
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        clickOnPlant();
    }
    private void clickOnPlant()
    {   
        if (input.Player.Select.triggered && Vector2.Distance(gameObject.transform.position, player.transform.position) < 2) 
        {
            gameObject.GetComponent<AudioSource>().Play();
            animator.SetTrigger("Water");
            switch (spriteRenderer.sprite.name)
            {
                case ("WheatLevel1"):
                    spriteRenderer.sprite = wheatSprites[1];
                    break;
                case ("WheatLevel2"):
                    spriteRenderer.sprite = wheatSprites[2];
                    break;
                case ("WheatLevel3"):
                    spriteRenderer.sprite = wheatSprites[3];
                    break;
                case ("WheatLevel4"):
                    gameObject.SetActive(false);
                    wheatNum++;
                    wheatCount.text = wheatNum.ToString();
                    break;
            }
            
        }
    }
}
