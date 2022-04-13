using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public void Init(spriteData cardData, int value)
    {
        GetComponent<Image>().sprite = cardData.spriteIcon[value];
        GetComponent<RectTransform>().name = cardData.name[value];
    }

    private void OnMouseDown()
    {
        FindObjectOfType<gameStateContoller>().LoseOrWin(gameObject.name);
    }
}
