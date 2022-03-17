using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class Field : MonoBehaviour
{
    //private CardData cardData;
    //private cellAnimation cellAnimation;
    //private Cell Cell;

    [Tooltip("Список настроек для иконок")]
    [SerializeField] public List<CardData> cardDataList;

    [Tooltip("Кол-во объектов на поле")]
    [SerializeField] public int FieldSize;

    [Tooltip("Базовый префаб иконок")]
    [SerializeField] private GameObject cellPref;

    [SerializeField] private float CellSize;
    [SerializeField] private float Spacing;

    [SerializeField] private RectTransform rt;

    private GameObject[] field;
    public List<int> randomList = new List<int>();

    public void GenerateField()
    {
        if (field == null)
        {
            randomWithoutDuplicate();
            CreateField();
        }
    }

    private void CreateField()
    {

        field = new GameObject[FieldSize]; //инициализируем массив
        float fieldWidth = FieldSize * (CellSize + Spacing) + Spacing; // считаем ширину поля
        rt.sizeDelta = new Vector2(fieldWidth, CellSize + Spacing); // устанавливаем размер на canvas

        float startX = -(fieldWidth / 2) + (CellSize / 2) + Spacing; // нач.позиции для первой клетки
        float startY = (fieldWidth / 2) - (CellSize / 2) - Spacing;

        var sprite = cellPref.GetComponent<Cell>();

        //заполняем поле и создаём объекты по префабу
        for (int x = 0; x < field.Length; x++)
        {
            sprite.Init(cardDataList[randomList[x]]);
            var cell = Instantiate(cellPref, transform, false);

            //Debug.Log(cardDataList[randomList[x]].name + "<<===");
            var position = new Vector2(startX + (x * (CellSize + Spacing)), 0);
            cell.transform.localPosition = position;

            field[x] = cell; // созданный объект заносим в массив
        }
    }

    private List<int> randomWithoutDuplicate()
    {
        var rnd = new System.Random();
        randomList = Enumerable.Range(0, cardDataList.Count).OrderBy(x => rnd.Next()).Take(cardDataList.Count).ToList();

        //for (int i = 0; i < cardDataList.Count; i++)
        //    Debug.Log(randomNumbers[i]);
        return randomList;
    }
    
}