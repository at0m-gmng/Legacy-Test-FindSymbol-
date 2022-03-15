using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class gameStateContoller : MonoBehaviour
{
    [Tooltip("Find symbol on cardDataList")]
    [SerializeField] private TextMeshProUGUI textSymbol;

    //[Tooltip("Список настроек для иконок")]
    //[SerializeField] private List<CardData> cardDataList;

    [SerializeField] private Field generationField;
    //[SerializeField] private Cell cell;

    void Start()
    {
        StartGame();
    }

    // очищаем кол-во очков и устанавливаем флаг начала игры
    private void StartGame()
    {
        generationField.GenerateField();
        textFindSymbol();
        //gameResult.text = "";

        //SetPoints(0); // обнуляем очки перед началом игры
        //GameStarted = true;

        //Field.Instance.GenerateField();
    }

    //public void LoseOrWin()
    //{
    //    //GameStarted = false;
    //    //gameResult.text = "You Win!";
    //    if (textSymbol.text == cardDataList[UnityEngine.Random.Range(0, cardDataList.Count)].name)
    //        Debug.Log("Win!");
    //    else
    //        Debug.Log("Lose!");
    //}

    //public void Lose()
    //{
    //    GameStarted = false;
    //    gameResult.text = "You Lose!";
    //}

    private void textFindSymbol()
    {
        textSymbol.text += " " + generationField.cardDataList[generationField.randomList[UnityEngine.Random.Range(0, 6)]].name;
    }


}
