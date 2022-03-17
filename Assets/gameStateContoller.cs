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
    private Cell cell;
    //private cellAnimation cellAnimation;
    //private cellAnimation cellAnimation = new cellAnimation();
    public static bool stateCheck = false;
    public static bool win = false;
    public static bool lose = false;

    private string tempSymbol;
    public List<string> findSymbolsList = new List<string>();
    public List<string> fieldSymbolsList = new List<string>();

    private void Start()
    {
        generationField.GenerateField();
        textGenerationSymbol();
        //cellAnimation.stateAnimation("lose");
        //Debug.Log(cell.rt);
        //for (int i = 0; i < findSymbolsList.Count; i++)
        //{
        //    Debug.Log(findSymbolsList[0]);
        //}
    }

    private void Update()
    {
        if (stateCheck)
        {
            for (int i = 0; i < findSymbolsList.Count; i++)
            {
                for (int j = 0; j < fieldSymbolsList.Count; j++)
                {
                    //Debug.Log(findSymbolsList[i]);
                    //Debug.Log(fieldSymbolsList[j]);
                    if (findSymbolsList[i] == fieldSymbolsList[j])
                    {
                        lose = false;
                        win = true;
                        Debug.Log("WIN!");
                    } else
                    {
                        win = false;
                        lose = true;
                    }
                }
            }
            stateCheck = false;
        }
    }

    public void LoseOrWin(string name)
    {
        int foundS1 = name.IndexOf("(");
        int foundS2 = name.IndexOf(")");
        name = name.Remove(foundS1, foundS2 - foundS1 +1);

        fieldSymbolsList.Add(name);
        //Debug.Log(fieldSymbolsList[0]);
        stateCheck = true;
        flagsOff();
        //if(textSymbol.text == name)
        //Debug.Log(gameObject.textSymbol.text);
        //for (int i = 0; i < findSymbolsList.Count; i++)
        //{
        //Debug.Log(gameStateContoller.findSymbolsList[0]);
        //break;
        //}
    }

    public void flagsOff()
    {
        win = false;
        lose = false;
        Debug.Log("stateCheck: " + stateCheck + " lose: " + lose + " <<==>> win: " + win);
    }

    //private void checkSymbols()
    //{
    //    for (int i = 0; i < findSymbolsList.Count; i++)
    //    {
    //        Debug.Log(findSymbolsList[0]);
    //    }
    //    for (int i = 0; i < fieldSymbolsList.Count; i++)
    //    {
    //        Debug.Log(fieldSymbolsList[0]);
    //    }
    //}

    private void textGenerationSymbol()
    {
        tempSymbol = generationField.cardDataList[generationField.randomList[UnityEngine.Random.Range(0, generationField.FieldSize)]].name;
        textSymbol.text += " " + tempSymbol;
        findSymbolsList.Add(tempSymbol);
    }


}
