using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spriteData", menuName = "Gameplay/New spriteData")]
public class SpriteData : ScriptableObject
{
    [SerializeField] private List<string> _spriteName = new List<string>();
    [SerializeField] private List<Sprite> _spriteIcon = new List<Sprite>();
    public List<string> SpriteName => this._spriteName;
    public List<Sprite> SpriteIcon => this._spriteIcon;
}
