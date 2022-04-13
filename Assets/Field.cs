using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using TMPro;

public class Field : MonoBehaviour
{
    [Tooltip("Данные об уровне")]
    [SerializeField] private LevelData levelData; // хранит данные об уровне 

    [Tooltip("Список наборов данных")]
    public List<spriteData> spriteDataList = new List<spriteData>(); // набор данных spriteData для генерации ячеек

    [Tooltip("Текущий набор данных для генерации")]
    public int numberSpriteData; // текущий выбранный spriteData из spriteDataList

    [Tooltip("Кол-во объектов на поле")]
    [SerializeField] public int FieldSize; // размерность поля

    [Tooltip("Базовый префаб иконок")]
    [SerializeField] private GameObject cellPref; // префаб генерируемой ячейки

    private float CellSize; // размер ячейки
    private float Spacing; // отступ между ячейками

    private RectTransform rt;

    private GameObject[] field;
    [SerializeField] public int current_level = 1; // текущий уровень
    public List<int> randomList = new List<int>(); // набор данных для генерации, отсортированный в случайном порядке

    private void Start()
    {
        CellSize = gameObject.GetComponent<GridLayoutGroup>().cellSize.x;
        Spacing = gameObject.GetComponent<GridLayoutGroup>().spacing.x;
        rt = GetComponent<RectTransform>();
        FieldSize = levelData.cell_count * current_level; // размер поля равен количеству добавляемых ячеек * на уровень
        randomData();
        GenerateField();
    }

    private void GenerateField()
    {
        //Debug.Log(FieldSize);
        if (field == null)
        {
            randomWithoutDuplicate();
            CreateField();
        }
    }

    // пересоздание поля с повышением уровня
    public void UpdateField()
    {
            FieldSize = levelData.cell_count * current_level;
            ClearField(); 
            randomData();
            randomWithoutDuplicate();
            CreateField();
    }

    // очищаем поле перед созданием нового
    private void ClearField() 
    {
        foreach (GameObject field in field)
        {
            Destroy(field.gameObject);
        }
    }

    //генерируем поле
    private void CreateField()
    {
        field = new GameObject[FieldSize]; //инициализируем массив
        float fieldWidth = FieldSize / current_level * (CellSize + Spacing) + Spacing; // считаем ширину поля
        float fieldHight = current_level * (CellSize + Spacing) + Spacing; // считаем высоту поля

        rt.sizeDelta = new Vector2(fieldWidth, fieldHight); // устанавливаем размер на canvas
        //float startX = -(fieldWidth / 2) + (CellSize / 2) + Spacing/2; // нач.позиции для первой клетки
        //float startY = (fieldWidth / 2) - (CellSize / 2) - Spacing;

        var sprite = cellPref.GetComponentInChildren<Cell>();

        //заполняем поле и создаём объекты по префабу
        for (int x = 0; x < field.Length; x++)
        {
            sprite.Init(spriteDataList[numberSpriteData], randomList[x]); 
            var cell = Instantiate(cellPref, transform, false);

            //спрайты с данным именем развёрнуты, разворачиваем их
            if ((spriteDataList[numberSpriteData].name[randomList[x]] == "7") || (spriteDataList[numberSpriteData].name[randomList[x]] == "8"))
                cell.transform.Rotate(0, 0, -90);
            else
                cell.transform.Rotate(0, 0, 0);

            //var position = new Vector2(0 + (x * (CellSize + Spacing)), 0);
            //cell.transform.localPosition = position;
            field[x] = cell; // созданный объект заносим в массив
        }
    }

    // выбираем случайный набор данных
    private int randomData()
    {
        numberSpriteData = UnityEngine.Random.Range(0, spriteDataList.Count);

        return numberSpriteData;
    }
    //распологаем данные в случайном порядке
    private List<int> randomWithoutDuplicate()
    {
        var rnd = new System.Random();
        randomList = Enumerable.Range(0, spriteDataList[numberSpriteData].spriteIcon.Count).OrderBy(x => rnd.Next()).Take(spriteDataList[numberSpriteData].spriteIcon.Count).ToList();

        //for (int i = 0; i < cardDataList.Count; i++)
        //    Debug.Log(randomNumbers[i]);
        return randomList;
    }
    
}