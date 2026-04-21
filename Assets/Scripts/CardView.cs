using UnityEngine;
using DG.Tweening;
using System.Security.Cryptography;


/// <summary>
/// Handles setting the visual aspects of a card
/// such as what sprite should be used to render the image on a card
/// </summary>
public class CardView : MonoBehaviour
{
    /// <summary> Contains data about the properties of this card </summary>
    [SerializeField] private BaseCard CardDetails;
    /// <summary> Card cover's sprite renderer </summary>
    [SerializeField] private SpriteRenderer _cardRenderer;
    /// <summary>TODO: determine usage</summary>
    [SerializeField] private GameObject _screenFilter;
    /// <summary> Value of how much we should zoom into the card when collected </summary>
    public float ZoomValue = 8f;

    #region Initialization

    /// <summary> Set the image of the card on awake </summary>
    private void Awake()
    {
        SetCardImage();
    }

    #endregion

    #region Set & Get Card Props

    /// <summary> Set the card image of this card by setting the
    /// sprite to be rendered by the sprite renderer </summary>
    public void SetCardImage()
    {
        _cardRenderer.sprite = CardDetails.CardImage;
    }


    /// <summary> Return the index of the cutscene tied to this card </summary>
    /// <returns> scene index of this card's cutscene </returns>
    public int GetSceneIndex() { return CardDetails.CutsceneIndex; }

    #endregion

    #region Card Animations

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

    public void RotateAroundYAxis()
    {
        transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.LocalAxisAdd);
    }

    #endregion

}
