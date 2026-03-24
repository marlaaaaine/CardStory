using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerInputHandler : MonoBehaviour
{
    private InputAction _moveAction, _jumpAction;
    private PlayerController _characterController;
    private void Awake()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");

        _jumpAction.performed += Jump;

        _characterController = GetComponent<PlayerController>();
    }

    /// <summary>
    /// Based on the player input (if space bar is pressed), make the player jump
    /// </summary>
    /// <param name="context"></param>
    private void Jump(InputAction.CallbackContext context)
    {
        // call character jump
        _characterController.Jump();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = _moveAction.ReadValue<Vector2>();
        // call character move
        _characterController.Move(moveVector);
    }
}
