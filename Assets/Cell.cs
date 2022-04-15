using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    //private SpriteData spriteData;
    private SpriteData spriteData;
    private gameStateContoller gameStateContoller;

    private void Start()
    {
        gameStateContoller = FindObjectOfType<gameStateContoller>();
    }
    //public List<spriteData> spriteDataList;
    public void Init(SpriteData _spriteData, int value)
    {
        spriteData = _spriteData;
        GetComponent<Image>().sprite = spriteData.SpriteIcon[value];
        GetComponent<RectTransform>().name = spriteData.SpriteName[value];
    }

    private void OnMouseDown()
    {
        gameStateContoller.LoseOrWin(gameObject.name);
    }
}
