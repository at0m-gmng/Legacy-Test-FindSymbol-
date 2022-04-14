using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private SpriteData spriteData; 
    //public List<spriteData> spriteDataList;
    public void Init(SpriteData _spriteData, int value)
    {
        spriteData = _spriteData;
        GetComponent<Image>().sprite = spriteData.spriteIcon[value];
        GetComponent<RectTransform>().name = spriteData.name[value];
    }

    private void OnMouseDown()
    {
        FindObjectOfType<gameStateContoller>().LoseOrWin(gameObject.name);
    }
}
