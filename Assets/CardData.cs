using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CardData", menuName = "Gameplay/New CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _spriteIcon;

    public string name => this._name;
    public Sprite spriteIcon => this._spriteIcon;
}
