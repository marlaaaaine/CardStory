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
    /// <summary> Action that gets invoked when a card has been collected </summary>
    public Action OnCollected;
    /// <summary> Bool that tells whether or not the card has been collected by the player </summary>
    public bool IsCollected;

    /// <summary> Getter/Setter for IsCollected bool
    /// When the bool is set to true, invoke the OnCollected action </summary>
    public bool CollectedBool
    {
        get { return IsCollected; }
        set
        {
            if (IsCollected != value)
            {
                IsCollected = value;
                if (IsCollected)
                {
                    OnCollected?.Invoke();
                }
            }
        }
    }


}
