using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollector : MonoBehaviour
{
    [HideInInspector]
    public bool isFound = false;
    public bool stepComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            isFound = true;
            stepComplete = true;
        }
    }
}
