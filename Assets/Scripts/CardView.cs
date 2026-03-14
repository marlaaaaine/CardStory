using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

/// <summary>
/// Handles setting the visual aspects of a card
/// such as what sprite should be used to render the image on a card
/// </summary>
public class CardView : MonoBehaviour
{   
    /// <summary>
    /// Contains data about the properties of this card
    /// </summary>
    [SerializeField] private BaseCard CardDetails;
    /// <summary>
    /// Card's sprite renderer
    /// </summary>
    [SerializeField] private SpriteRenderer _spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Set the cover image of this card by setting the
    /// sprite to be rendered by the sprite renderer
    /// </summary>
    public void SetCover()
    {
        _spriteRenderer.sprite = CardDetails.CardCover;
    }
    // TODO: I want code for setting the card cover and also the effects for when the card appears on screen when collected
    
}
