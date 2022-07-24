using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowScript : MonoBehaviour
{
    public GameObject cowCommentaryPanel;
    public Text cowText;
    public Text wheatText;
    public Text milkCount;
    public GameObject player;
    public GameObject cremeCat;
    PlayerInput input;
    private bool milkedCow = false;
    private AudioSource milkCollected;

    private void Awake()
    {
        input = new PlayerInput();
        milkCollected = gameObject.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
    private void Update()
    {
        CheckIfCowMilked();
    }


    private void CheckIfCowMilked()
    {
        if (input.Player.Select.triggered && Vector2.Distance(gameObject.transform.position, player.transform.position) < 2)
        {
            if (milkedCow == false)
            {
                Milk();
            }
            else
            {
                cowCommentaryPanel.SetActive(true);
                cowText.text = "You already milked this cow!";
            }

        }
    }

    public void Milk()
    {
        int wheatNum = int.Parse(wheatText.text);
        int milkNum = int.Parse(milkCount.text);
        
            if(wheatNum > 0)
            {
                wheatNum--;
                wheatText.text = wheatNum.ToString();
                cowText.text = "You collected 1 milk!";
                milkCollected.Play();
                milkNum++;
                milkCount.text = milkNum.ToString();
                cowCommentaryPanel.SetActive(true);
                milkedCow = true;
        }
            else
            {
                cowCommentaryPanel.SetActive(true);
                cowText.text = "Go find some food for the cow!";
            }
        if(milkNum == 4)
        {
            cowCommentaryPanel.SetActive(true);
            cowText.text = "Yay, you got 4 milk! The creme cat has appeared!";
            cremeCat.SetActive(true);
        }
    }

    
    
}
