using System;
using UnityEngine;

/// <summary>
/// Scriptable object holding data for a card. 
/// </summary>
[CreateAssetMenu(fileName = "BaseCard", menuName = "Scriptable Objects/Create Card")]
public class BaseCard : ScriptableObject
{
    /// <summary> Image representing the card </summary>
    public Sprite CardCover;
    /// <summary> Card background </summary>
    public Sprite CardBG;



}
