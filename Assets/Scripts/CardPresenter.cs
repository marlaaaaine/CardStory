using System;
using UnityEngine;

/// <summary>
/// Communicates with the CardView to represent the state of a card in game
/// </summary>
public class CardPresenter : MonoBehaviour
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// When the player collides with a card, invoke the OnCollected event
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        CollectedBool = true;
    }
}
