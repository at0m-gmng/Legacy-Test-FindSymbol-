using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Gameplay/New spriteData")]
public class spriteData : ScriptableObject
{
    [SerializeField] private List<string> _name = new List<string>();
    [SerializeField] private List<Sprite> _spriteIcon = new List<Sprite>();
    public List<string> name => this._name;
    public List<Sprite> spriteIcon => this._spriteIcon;
}

[CreateAssetMenu(fileName = "CardData", menuName = "Gameplay/New LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _level_Count;
    [SerializeField] private int _cell_count;

    public int level_Count => this._level_Count;
    public int cell_count => this._cell_count;
}
