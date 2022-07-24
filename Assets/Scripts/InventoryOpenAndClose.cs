using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpenAndClose : MonoBehaviour
{
  public void OpenAndClose()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }else if(gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
    }
}
