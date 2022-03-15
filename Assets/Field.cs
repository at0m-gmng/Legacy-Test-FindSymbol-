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

    [Tooltip("Список настроек для иконок")]
    [SerializeField] public List<CardData> cardDataList;

    [Tooltip("Кол-во объектов на поле")]
    [SerializeField] private int FieldSize;

    [Tooltip("Базовый префаб иконок")]
    [SerializeField] private GameObject cellPref;

    //[Tooltip("Find symbol on cardDataList")]
    //[SerializeField] private TextMeshProUGUI textSymbol;

    //[Tooltip("Время между спавном иконок")]
    //[SerializeField] private float spawnTime;

    //public static Dictionary<GameObject, Cell> cell;
    //private Queue<GameObject> currentCell;

    //[SerializeField] private int FieldSize = 3;
    [SerializeField] private float CellSize;
    [SerializeField] private float Spacing;

    //[SerializeField] private Cell cellPref;
    [SerializeField] private RectTransform rt;

    //private Cell cellCell;
    private GameObject[] field;
    //private int rand;
    public List<int> randomList = new List<int>();

    //void Start()
    //{
    //cellPref.width = CellSize;

    //randomList = new List<int>(new int[cardDataList.Count]);
    //    GenerateField();
    //}



    public void GenerateField()
    {
        if (field == null)
            CreateField();
    }

    private void CreateField()
    {
        randomList = randomWithoutDuplicate();

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

            Debug.Log(cardDataList[randomList[x]].name + "<<===");

            var position = new Vector2(startX + (x * (CellSize + Spacing)), 0);
            cell.transform.localPosition = position;

            field[x] = cell; // созданный объект заносим в массив
        }
    }

    private List<int> randomWithoutDuplicate()
    {
        var rnd = new System.Random();
        var randomNumbers = Enumerable.Range(0, cardDataList.Count).OrderBy(x => rnd.Next()).Take(cardDataList.Count).ToList();
        for (int i = 0; i < cardDataList.Count; i++)
        {

            Debug.Log(randomNumbers[i]);
        }

        return randomNumbers;
    }

    //private void textFindSymbol()
    //{
    //    textSymbol.text += " "+ cardDataList[UnityEngine.Random.Range(0, cardDataList.Count)].name;
    //}
    
}