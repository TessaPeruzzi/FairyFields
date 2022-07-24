using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue Information")]
    public Text text;
    public string[] dialogue;
    public float textSpeed;

    [Header("Sprite Images")]
    public SpriteRenderer player;
    public SpriteRenderer fairy;

    [Header("Sprite Emotions")]
    public Sprite[] playerEmotions;
    public Sprite[] fairyEmotions;

    private int index;
    private void Start()
    {
        text.text = string.Empty;
        StartDialogue();
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in dialogue[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            player.sprite = playerEmotions[index];
            fairy.sprite = fairyEmotions[index];
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if(SceneManager.GetActiveScene().name == "Intro Cutscene")
            {
                SceneManager.LoadScene("GameArea");
            }
        }
    }

    public void MoveOn()
    {
        if(text.text == dialogue[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            text.text = dialogue[index];
        }
    }
}
