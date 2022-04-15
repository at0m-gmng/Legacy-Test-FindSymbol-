using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "levelData", menuName = "Gameplay/New levelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _levelCount;
    [SerializeField] private int _cellcount;

    public int LevelCount => this._levelCount;
    public int CellCount => this._cellcount;
}
