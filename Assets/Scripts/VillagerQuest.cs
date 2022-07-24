using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagerQuest : MonoBehaviour
{
    public GameObject dialogueOverlay;
    public GameObject woodPieces;
    public GameObject pinkCat;
    private CatCollector pinkCatFound;
    public Text woodText;
    public Text villagerDialogue;
    public string[] dialogue;
    private bool questComplete = false;
    public float textSpeed;
    private int index = 0;
    private int talkCount;

    private void Start()
    {
        villagerDialogue.text = string.Empty;
        pinkCatFound = pinkCat.GetComponent<CatCollector>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && talkCount == 0 && questComplete == false)
        {
            woodPieces.SetActive(true);
            dialogueOverlay.SetActive(true);
            StartDialogue();
            talkCount++;
        }else if(collision.gameObject.tag == "Player" && talkCount != 0 && woodText.text == "10" && questComplete == false)
        {
            villagerDialogue.text = string.Empty;
            dialogueOverlay.SetActive(true);
            index = 7;
            StartDialogue();
            pinkCat.SetActive(false);
            pinkCatFound.isFound = true;
            pinkCatFound.stepComplete = true;
            questComplete = true;
            woodText.text = "0";
        }
        else if (collision.gameObject.tag == "Player" && talkCount != 0 && woodText.text != "10"  && questComplete == false)
        {
            villagerDialogue.text = string.Empty;
            dialogueOverlay.SetActive(true);
            index = 6;
            StartDialogue();
        }
        else if (collision.gameObject.tag == "Player" && questComplete == true)
        {
            villagerDialogue.text = string.Empty;
            dialogueOverlay.SetActive(true);
            index = 8;
            StartDialogue();
        }


    }

    void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue[index].ToCharArray())
        {
            villagerDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if(talkCount == 1)
        {
            if (index < 5)
            {
                index++;
                villagerDialogue.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                dialogueOverlay.SetActive(false);
            }
        }


    }
    public void MoveOn()
    {
        if (villagerDialogue.text == dialogue[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            villagerDialogue.text = dialogue[index];
        }
    }
}
