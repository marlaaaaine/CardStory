using System;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// Communicates with the CardView to represent the state of a card in game
/// </summary>
public class CardPresenter : MonoBehaviour
{

    /// <summary> Keep track of the current COLLECTED card </summary>
    public static CardPresenter CollectedCard;
    /// <summary> Action that gets invoked when a card has been collected </summary>
    public Action OnCollected;
    /// <summary> Bool that tells whether or not the card has been collected by the player </summary>
    public bool IsCollected;
    /// <summary> class controlling the visual aspects of the card </summary>
    [SerializeField] CardView _view;

    #region Getter&Setters
    /// <summary> Getter/Setter for IsCollected bool
    /// When the bool is set to true, invoke the OnCollected action </summary>
    public bool CollectedBool
    {
        get { return IsCollected; }
        set
        {
            if (IsCollected != value) // is the value being set different than the current value?
            {
                IsCollected = value;
                if (IsCollected)
                {
                    CollectedCard = this;
                    OnCollected?.Invoke();
                }
            }
        }
    }
    #endregion

    #region Unity Methods
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        OnCollected += CollectCard;
    }

    /// <summary> Called when this object is destroyed </summary>
    private void OnDestroy()
    {
        OnCollected -= CollectCard;
    }


    /// <summary>
    /// When the player collides with a card, invoke the OnCollected event
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other.gameObject.name} collided with card");
        CollectedBool = true;
    }

    #endregion

    #region Card Collection

    /// <summary> What should happen when a card is collected? There should be an animation bringing
    /// the card to the center of the screen, then zoom in to the card to view its details.
    /// The scene behind it should be frozen, put a filter over the background. Nothing should
    /// be interactable other than the card. </summary>
    public void CollectCard()
    {
        Debug.Log("Something should happen when the card is collected");
        // Disable player movement, TODO: remember to set to true somewhere
        PlayerInputHandler.CanMove = false;
        _view.AnimateCardCollection();
    }

    /// <summary> What should happen when the player interacts with the card? </summary>
    public void InteractWithCard()
    {
        Debug.Log("Card has been interacted with ");
        // rotate da card
        _view.RotateAroundYAxis();
        // start asynch loading the next scene
        // - need to have the cutscene manager start the coroutine itself rather than
        // in the CardPresenter because if the CardPresenter does it then
        // it relies on the CardPresenter object being there to finish the coroutine
        CutSceneManager.Instance.LoadScene(_view.GetSceneIndex());
        // once the card in the level has been collected,
        // the player can proceed into the next level being asynch loaded
        CutSceneManager.Instance.CanPlayerProceed = true;
        // allow player to move after each
        // asynch load because each card will trigger the loading
        // which is the only time when the player is stopped
        PlayerInputHandler.CanMove = true;
        // destroy this card
        Destroy(gameObject, 1f);
    }

    #endregion


}
