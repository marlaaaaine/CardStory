using UnityEngine;
using DG.Tweening;


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
    [SerializeField] private SpriteRenderer _coverRenderer;
    [SerializeField] private SpriteRenderer _bgRenderer;
    [SerializeField] private GameObject _screenFilter;
    /// <summary> Value of how much we should zoom into the card when collected </summary>
    public float ZoomValue = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        SetCover();
        SetBackground();
    }

    /// <summary>
    /// Set the cover image of this card by setting the
    /// sprite to be rendered by the sprite renderer
    /// </summary>
    public void SetCover()
    {
        _coverRenderer.sprite = CardDetails.CardCover;
    }

    public void SetBackground()
    {

    }

    /// <summary> How the card should be animated when it is collected summary>
    public void AnimateCardCollection()
    {
        // Set the filter to be visible/active in scene
        //_screenFilter.SetActive(true);
        // Fix card rotation (made to look like it's on ground before pick up)
        transform.localRotation = Quaternion.identity;
        // Move the card to the center
        Vector3 screenCenterPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
        transform.DOMove(screenCenterPos, 1f).SetEase(Ease.OutQuad);
        // Scale animation
        transform.DOScale(ZoomValue, 0.3f).SetEase(Ease.OutBack);
    }
    // TODO: I want code for setting the card cover and also the effects for when the card appears on screen when collected

}
