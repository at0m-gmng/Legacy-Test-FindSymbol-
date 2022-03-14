using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private CardData cardData;
    public float width;

    RectTransform rt;
    private void Start()
    {
        rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, width);
    }

    public void Init(CardData _cardData)
    {
        cardData = _cardData;
        GetComponent<Image>().sprite = cardData.spriteIcon;
        GetComponent<RectTransform>().name = cardData.name;
    }
}
