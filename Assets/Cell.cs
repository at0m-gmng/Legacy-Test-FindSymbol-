using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private CardData cardData;
    //private gameStateContoller gameStateContoller = new gameStateContoller();
    //public cellAnimation cellAnimation = new cellAnimation();
    //public cellAnimation cellAnimation;
    public float width;

    public RectTransform rt;
    BoxCollider2D bd;
    //public cellAnimation cellAnimation;
    //Button bt;

    private void Start()
    {
        //cellAnimation = GetComponent<cellAnimation>();
        rt = GetComponent<RectTransform>();
        bd = GetComponent<BoxCollider2D>();
        //bt = GetComponent<Button>();
        bd.size = new Vector2(width, width);
        rt.sizeDelta = new Vector2(width, width);
    }

    public void Init(CardData _cardData)
    {
        cardData = _cardData;
        GetComponent<Image>().sprite = cardData.spriteIcon;
        GetComponent<RectTransform>().name = cardData.name;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<gameStateContoller>().LoseOrWin(gameObject.name);
        //gameStateContoller.LoseOrWin(gameObject.name);
    }
}
