using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputHandler : MonoBehaviour
{
    /// <summary> input actions for moving and jumping </summary>
    private InputAction _moveAction, _jumpAction, _interactAction;
    /// <summary> script that controls player movement </summary>
    private PlayerController _characterController;

    /// <summary>Bool for whether the player can move.</summary>
    public static bool CanMove { get; set; }
    private void Awake()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _interactAction = InputSystem.actions.FindAction("Interact");

        _jumpAction.performed += Jump;
        _interactAction.started += Interact;

        _characterController = GetComponent<PlayerController>();

        // starting default value
        CanMove = true;
    }

    /// <summary> Based on the player input (if space bar is pressed), make the player jump </summary>
    /// <param name="context"></param>
    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump was called");
        // call character jump
        if (CanMove) _characterController.Jump();
    }

    /// <summary> Based on the player input (if the 'E' key is pressed), trigger what happens when you
    /// interact with a card (animation and scene transition) </summary>
    /// <param name="context"></param>
    private void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("There should be an interaction");
        if (CardPresenter.CurrentCollectedCard != null)
        {
            CardPresenter.CurrentCollectedCard.InteractWithCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove)
        {
            Vector2 moveVector = _moveAction.ReadValue<Vector2>();
            // call character move
            _characterController.Move(moveVector);
        }
        else
        {
            // Stop the player
            _characterController.Move(Vector2.zero, false);
        }
    }
}
