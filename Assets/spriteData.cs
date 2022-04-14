using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spriteData", menuName = "Gameplay/New spriteData")]
public class spriteData : ScriptableObject
{
    [SerializeField] private List<string> _name = new List<string>();
    [SerializeField] private List<Sprite> _spriteIcon = new List<Sprite>();
    public List<string> name => this._name;
    public List<Sprite> spriteIcon => this._spriteIcon;
}
