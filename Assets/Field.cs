using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Field : MonoBehaviour
{
    //private CardData cardData;

    [Tooltip("Список настроек для иконок")]
    [SerializeField] private List<CardData> cardDataList;

    [Tooltip("Кол-во объектов в пуле")]
    [SerializeField] private int FieldSize;

    [Tooltip("Базовый префаб иконок")]
    [SerializeField] private GameObject cellPref;

    //[Tooltip("Время между спавном иконок")]
    //[SerializeField] private float spawnTime;

    //public static Dictionary<GameObject, Cell> cell;
    //private Queue<GameObject> currentCell;

    //[SerializeField] private int FieldSize = 3;
    [SerializeField] private float CellSize;
    [SerializeField] private float Spacing;

    //[SerializeField] private Cell cellPref;
    [SerializeField] private RectTransform rt;

    private Cell cellCell;
    private GameObject[] field;
    private int rand;
    private List<int> randomList = new List<int>();

    void Start()
    {

        //cellPref.width = CellSize;
        randomList = new List<int>(new int[cardDataList.Count]);
        
        GenerateField();

        //cell = new Dictionary<GameObject, Cell>();
        //currentCell = new Queue<GameObject>();

        //for (int i = 0; i < FieldSize; ++i)
        //{
        //    var prefab = Instantiate(cellPref);
        //    var script = prefab.GetComponent<Cell>();
        //    //prefab.SetActive(false);
        //    cell.Add(prefab, script);
        //    currentCell.Enqueue(prefab);

        //int rand = UnityEngine.Random.Range(0, cardDataList.Count);
        //    script.Init(cardDataList[rand]);

        //}
    }
    
    private void CreateField()
    {
        randomWithoutDuplicate();

        field = new GameObject[FieldSize]; //инициализируем массив
        float fieldWidth = FieldSize * (CellSize + Spacing) + Spacing; // считаем ширину поля
        //if (fieldWidth >= 1000) // считаем размер клеток, когда размер поля максимально
        //{
        //    fieldWidth = 1000f;
        //    Spacing = fieldWidth * 0.02f;
        //    CellSize = (fieldWidth - Spacing) / FieldSize - Spacing;
        //    cellPref.width = CellSize;
        //}

        rt.sizeDelta = new Vector2(fieldWidth, CellSize + Spacing); // устанавливаем размер на canvas

        float startX = -(fieldWidth / 2) + (CellSize / 2) + Spacing; // нач.позиции для первой клетки
        float startY = (fieldWidth / 2) - (CellSize / 2) - Spacing;

        var sprite = cellPref.GetComponent<Cell>();

        //заполняем поле и создаём объекты по префабу
        for (int x = 0; x < FieldSize+1; x++)
        {
            var cell = Instantiate(cellPref, transform, false); //startY - (y * (CellSize + Spacing))
            //int rand = UnityEngine.Random.Range(0, cardDataList.Count);

            sprite.Init(cardDataList[randomList[x]-1]);
            Debug.Log(cardDataList[randomList[x]-1] + " <<=====");

            //for(int i = 0; i < randomList.Length; i ++)
            //{
            //Debug.Log(randomList[0]);
            //}
            var position = new Vector2(startX + (x * (CellSize + Spacing)), 0);
            cell.transform.localPosition = position;

            field[x] = cell; // созданный объект заносим в массив
            if (field[0])
                Destroy(field[0]);
        }
        

        
    }

    private void randomWithoutDuplicate()
    {
        for (int i = 0; i < cardDataList.Count; i++)
        {
            rand = UnityEngine.Random.Range(1, cardDataList.Count + 1);
            while (randomList.Contains(rand))
            {
                rand = UnityEngine.Random.Range(1, cardDataList.Count + 1);
            }
            randomList[i] = rand;
            Debug.Log(randomList[i]);
        }

        //for(int i = 0; i < cardDataList.Count; i++)
        //{
        //    randomList.Add(i);
        //}
        //randomList = randomList.OrderBy(tvz => System.Guid.NewGuid()).ToList();

        //for (int i = 0; i < randomList.Count; i++)
        //{
        //    Debug.Log(randomList[i]);
        //}
    }

    private void GenerateField()
    {
        if (field == null)
            CreateField();

        //for (int x = 0; x < FieldSize; x++)
        //    for (int y = 0; y < FieldSize; y++)
        //        field[x, y].SetValue(x, y, 0);

        //for (int i = 0; i < InitCellsCount; i++)
        //    GenerateRandomCell();
    }
    
}