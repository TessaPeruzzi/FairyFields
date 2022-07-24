using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player Information")]
    public GameObject player;
    public GameObject playerHealth1;
    public GameObject playerHealth2;
    public GameObject playerHealth3;
    private Image playerHealth1Icon;
    private Image playerHealth2Icon;
    private Image playerHealth3Icon;
    private Health playerHealth;

    [Header("Cat Icon Information")]
    public GameObject cremeCatIcon;
    public GameObject orangeCatIcon;
    public GameObject pinkCatIcon;
    public GameObject blackCatIcon;
    private Image cremeCatSprite;
    private Image orangeCatSprite;
    private Image pinkCatSprite;
    private Image blackCatSprite;

    [Header("Cat Game Object Information")]
    public GameObject pinkCat;
    public GameObject blackCat;
    public GameObject cremeCat;
    public GameObject orangeCat;

    private CatCollector pinkCollector;
    private CatCollector blackCollector;
    private CatCollector cremeCollector;
    private CatCollector orangeCollector;

    private AudioSource pinkAudio;
    private AudioSource blackAudio;
    private AudioSource cremeAudio;
    private AudioSource orangeAudio;

    [Header("UI for Winning")]
    public GameObject wonPanel;
    private void Start()
    {
        cremeCatSprite = cremeCatIcon.GetComponent<Image>();
        blackCatSprite = blackCatIcon.GetComponent<Image>();
        pinkCatSprite = pinkCatIcon.GetComponent <Image>();
        orangeCatSprite = orangeCatIcon.GetComponent<Image>();

        playerHealth1Icon = playerHealth1.GetComponent<Image>();
        playerHealth2Icon = playerHealth2.GetComponent<Image>();
        playerHealth3Icon = playerHealth3.GetComponent<Image>();


        pinkCollector = pinkCat.GetComponent<CatCollector>();
        blackCollector = blackCat.GetComponent<CatCollector>();
        cremeCollector = cremeCat.GetComponent<CatCollector>();
        orangeCollector = orangeCat.GetComponent<CatCollector>();

        playerHealth = player.GetComponent<Health>();

        pinkAudio = pinkCatIcon.GetComponent<AudioSource>();
        blackAudio = blackCatIcon.GetComponent<AudioSource>();
        cremeAudio = cremeCatIcon.GetComponent<AudioSource>();
        orangeAudio = orangeCatIcon.GetComponent <AudioSource>();
    }
    private void Update()
    {
        EndGame();
        ChangePlayerHealthIcon();
        ChangeIcon();
    }

    private void ChangeIcon()
    {
        if(pinkCollector.isFound == true)
        {
            pinkCatSprite.color = new Color(255, 255, 255, 255);
            pinkAudio.Play();
            pinkCollector.isFound = false;
        }
        if (blackCollector.isFound == true)
        {
            blackCatSprite.color = new Color(255, 255, 255, 255);
            blackAudio.Play();
            blackCollector.isFound = false;
        }
        if (cremeCollector.isFound == true)
        {
            cremeCatSprite.color = new Color(255, 255, 255, 255);
            cremeAudio.Play();
            cremeCollector.isFound = false; 
        }
        if (orangeCollector.isFound == true)
        {
            orangeCatSprite.color = new Color(255, 255, 255, 255);
            orangeAudio.Play();
            orangeCollector.isFound = false;
        }
    }

    private void ChangePlayerHealthIcon()
    {
        if(playerHealth.currentHealth == 3)
        {
            playerHealth1Icon.color = new Color(255, 255, 255, 255);
            playerHealth2Icon.color = new Color(255, 255, 255, 255);
            playerHealth3Icon.color = new Color(255, 255, 255, 255);
        }
        if (playerHealth.currentHealth == 2)
        {
            playerHealth1Icon.color = new Color(255, 255, 255, 255);
            playerHealth2Icon.color = new Color(255, 255, 255, 255);
            playerHealth3Icon.color = new Color(255, 255, 255, 0);
        }
        if (playerHealth.currentHealth == 1)
        {
            playerHealth1Icon.color = new Color(255, 255, 255, 255);
            playerHealth2Icon.color = new Color(255, 255, 255, 0);
            playerHealth3Icon.color = new Color(255, 255, 255, 0);
        }
        if (playerHealth.currentHealth == 0)
        {
            playerHealth1Icon.color = new Color(255, 255, 255, 0);
            playerHealth2Icon.color = new Color(255, 255, 255, 0);
            playerHealth3Icon.color = new Color(255, 255, 255, 0);
        }
    }

    private void EndGame()
    {
        if(orangeCollector.stepComplete == true && cremeCollector.stepComplete == true && blackCollector.stepComplete == true && pinkCollector.stepComplete == true)
        {
            Time.timeScale = 0;
            wonPanel.SetActive(true);
        }
    }
}
