using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "levelData", menuName = "Gameplay/New levelData")]
public class levelData : ScriptableObject
{
    [SerializeField] private int _level_Count;
    [SerializeField] private int _cell_count;

    public int level_Count => this._level_Count;
    public int cell_count => this._cell_count;
}
