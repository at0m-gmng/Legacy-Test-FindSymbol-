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
        textGenerationSymbol();
    }

    private void Update()
    {
        if (stateCheck)
        {
            for (int j = 0; j < fieldSymbolsList.Count; j++)
            {
                if (findSymbolsList[generationField.current_level - 1] == fieldSymbolsList[j])
                {
                    lose = false;
                    win = true;
                    //Debug.Log(findSymbolsList[generationField.current_level - 1] + "WIN!" + " You click: " + fieldSymbolsList[j]);

                    if (generationField.current_level < levelData.level_Count)
                    {
                        level_up();
                        stateCheck = false;
                    }
                    //Debug.Log(generationField.current_level);
                }
                else
                {
                    lose = true;
                    win = false;
                    //Debug.Log(findSymbolsList[generationField.current_level - 1] + "Lose!" + " You click: " + fieldSymbolsList[j]);
                }
                if (generationField.current_level == levelData.level_Count && (win || lose))
                {
                    Invoke("StopGame", .65f); // запускаем затемнение экрана только после анимации
                    //stopGame = true;
                    if (win)
                        Instantiate(winEffect, gameObject.transform);
                }
            }
            stateCheck = false;
        }
    }

    private void StopGame() { stopGame = true; }

    private void level_up()
    {
        Instantiate(winEffect, gameObject.transform);
        fieldSymbolsList = new List<string>();
        generationField.current_level++;
        generationField.UpdateField();
        textGenerationSymbol();
        flagsOff();
    }

    public void LoseOrWin(string name)
    {
        fieldSymbolsList.Add(name);
        stateCheck = true;
        flagsOff();
    }

    private void flagsOff()
    {
        win = false;
        lose = false;
        //Debug.Log("stateCheck: " + stateCheck + " lose: " + lose + " <<==>> win: " + win);
    }

    private void textGenerationSymbol()
    {
        tempSymbol = generationField.spriteDataList[generationField.numberSpriteData].name[generationField.randomList[UnityEngine.Random.Range(0, generationField.FieldSize)]];
        textSymbol.text = "";
        textSymbol.text += "Find " + tempSymbol;
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
                    textGenerationSymbol();
                }
            }
        }
    }
}
