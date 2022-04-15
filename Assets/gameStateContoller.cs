using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class gameStateContoller : MonoBehaviour
{
    [Tooltip("Find symbol on cardDataList")]
    [SerializeField] private TextMeshProUGUI textSymbol; // текстовое поле для вывода данных
    [SerializeField] private LevelData levelData; // данные о количестве уровней
    [SerializeField] private GameObject winEffect; // particle effect
    [SerializeField] private Field generationField; // игровое поле со сгенерированными ячейками

    private static bool stateCheck = false; // разрешена ли проверка на выигрышь
    private string tempSymbol; // текущий выбранный символ для Find "X"
    private List<string> findSymbolsList = new List<string>(); // хранит список текстовых элементов Find "X" 
    private List<string> fieldSymbolsList = new List<string>(); // хранит значения элементов на поле

    public static bool win = false; // переменные для проверки на выигрыш, проигрыш и воспроизведения соответственной анимации
    public static bool lose = false;
    public bool stopGame = false; // переменная для состояния активности игры

    private void Start()
    {
        TextGenerationSymbol();
    }

    private void Update()
    {
        if (!stateCheck)
            return;
        CheckState();
    }

    private void CheckState()
    {
        for (int j = 0; j < fieldSymbolsList.Count; j++)
        {
            if (findSymbolsList[generationField.currentLevel - 1] == fieldSymbolsList[j])
            {
                SetFlags(true, false);
                //Debug.Log(findSymbolsList[generationField.currentLevel - 1] + "WIN!" + " You click: " + fieldSymbolsList[j]);

                if (generationField.currentLevel < levelData.LevelCount)
                    LevelUp(); 
                //Debug.Log(generationField.currentLevel);
            }
            else
                SetFlags(false, true);
                //Debug.Log(findSymbolsList[generationField.currentLevel - 1] + "Lose!" + " You click: " + fieldSymbolsList[j]);

            if ((generationField.currentLevel == levelData.LevelCount) && win)
            {
                if (win)
                    Instantiate(winEffect, gameObject.transform);
                StartCoroutine(StopGame());
            }
            else if ((generationField.currentLevel == levelData.LevelCount) && lose)
                StartCoroutine(StopGame());
        }
        stateCheck = false;
    }

    IEnumerator StopGame()
    {
        yield return new WaitForSecondsRealtime(.65f);
        stopGame = true;
    }

    private void LevelUp()
    {
        Instantiate(winEffect, gameObject.transform);
        fieldSymbolsList = new List<string>();
        generationField.currentLevel++;
        generationField.UpdateField();
        TextGenerationSymbol();
        SetFlags(false,false);
    }

    public void LoseOrWin(string name)
    {
        fieldSymbolsList.Add(name);
        stateCheck = true;
        SetFlags(false,false);
    }

    private void SetFlags(bool isWin, bool isLose)
    {
        win = isWin;
        lose = isLose;
        //Debug.Log("stateCheck: " + stateCheck + " lose: " + lose + " <<==>> win: " + win);
    }

    private void TextGenerationSymbol()
    {
        tempSymbol = generationField.spriteDataList[generationField.numberSpriteData].SpriteName[generationField.randomList[UnityEngine.Random.Range(0, generationField.FieldSize)]];
        //textSymbol.text = "";
        //textSymbol.text += "Find " + tempSymbol;
        textSymbol.text = $"Find {tempSymbol}";
        findSymbolsList.Add(tempSymbol);

        for (int i = 0; i < findSymbolsList.Count; i++)
        {
            for (int j = i+1; j < findSymbolsList.Count; j++)
            {
                if (findSymbolsList[j] == findSymbolsList[i])
                {
                    // если найден повтор удаляем записанный символ и перевызываем функцию для генерации нового символа

                    //Debug.Log(findSymbolsList[j] + " Содержится!" + " Найден повтор: " + findSymbolsList[i]);
                    findSymbolsList.RemoveAt(j); 
                    TextGenerationSymbol();
                }
            }
        }
    }
}
