using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingManager : MonoBehaviour
{
    public GameObject fishUI;
    public Sprite[] fishSprites;
    public GameObject fishImage;
    public GameObject feedCatBtn;
    private SpriteRenderer fishRenderer;
    Text fishText;

    private void Start()
    {
        fishRenderer = fishImage.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fishUI.SetActive(true);
        }
    }

    public void Fish()
    {
        fishUI.SetActive(false);
        int randomValue = Random.Range(0,fishSprites.Length);
        fishRenderer.sprite = fishSprites[randomValue];
        fishText = fishUI.transform.GetChild(0).GetComponent<Text>();
        fishImage.SetActive(true);
        switch (fishSprites[randomValue].name)
        {
            case ("Trout"):
                fishText.text = "You caught the trout! Let's feed the cat!";
                break;
            case ("Bag"):
                fishText.text = "You caught trash! Try again?";
                break;
            case ("Algae"):
                fishText.text = "You caught algae! Try again?";
                break;
            case ("Goldfish"):
                fishText.text = "You caught a goldfish! Try again?";
                break;
            case ("Betta"):
                fishText.text = "You caught a betta! Try again?";
                break;
        }
        if(fishSprites[randomValue].name == "Trout")
        {
            feedCatBtn.SetActive(true);
            this.gameObject.SetActive(false);
        }
        fishUI.SetActive(true);
    }
}
