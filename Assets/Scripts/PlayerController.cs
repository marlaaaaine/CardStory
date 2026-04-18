
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary> the player's movement speed (how fast they move) and jump force (how high they jump) </summary>
    [SerializeField] private float _movementSpd = 5f, _jumpforce = 5f;
    /// <summary> reference to the player's rigid body </summary>
    [SerializeField] private Rigidbody2D _rigidBody;
    /// <summary> reference to script that handles setting the animation for the player </summary>
    [SerializeField] private AnimationController _animController;
    /// <summary> vector2 representing how much the player has moved </summary>
    private Vector2 _moveVector;
    private float _prevX = 0;
    /// <summary> the sum of the player's most recent movement </summary>
    private float _currentMovementSum = 0;
    /// <summary> records the sum of how much the player has moved before the next sum</summary>
    private float _prevMovementSum = 0;
    /// <summary> bool for whether the player has clicked the jump key or not </summary>
    private bool _jumpRequested = false;
    /// <summary> bool for whether the player is facing right or not </summary>
    private bool _facingRight = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animController = GetComponent<AnimationController>();

        _prevX = transform.position.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // record the sum before tracked values change
        _prevMovementSum = _prevX + transform.position.x;
        // track x value of player's position as they move
        _prevX = transform.position.x;
        // move the player horizontally using the _moveVector.x and movementSpd
        _rigidBody.linearVelocityX = _moveVector.x * _movementSpd;
        // sum the x values to see the player is moving more in the positive dir or negative dir
        _currentMovementSum = _prevX + transform.position.x;
        // if the player is moving in the positive direction and they aren't facing right, invert them to face right
        if (_currentMovementSum - _prevMovementSum > 0 && !_facingRight)
        {
            InvertPlayerDir();
        }
        // if the player is moving in the negative direction and they are facing right, invert them to face left
        else if (_currentMovementSum - _prevMovementSum < 0 && _facingRight)
        {
            InvertPlayerDir();
        }

        if (_jumpRequested)
        {
            _rigidBody.linearVelocityY = _jumpforce;
            _jumpRequested = false;
        }
    }

    /// <summary>
    /// Get the moveVector for the when the player moves and 
    /// store it in _moveVector. Determine what animation should be 
    /// playing (idle vs moving) based on whether the _moveVector is zero or not 
    /// </summary>
    /// <param name="moveVector"></param>
    public void Move(Vector2 moveVector, bool canAnimate = true)
    {
        // set the old _moveVector to the new input
        _moveVector = moveVector;

        if (canAnimate)
        {
            // play the move anim if the player has moved
            if (_moveVector == Vector2.zero) // no movement if movement = 0
            {
                _animController.SetAnimation(AnimationController.PlayerStateTypes.Idle);
            }
            else // movement != 0, player is moving
            {
                _animController.SetAnimation(AnimationController.PlayerStateTypes.Run);
            }
        }
        else
        {
            _animController.SetAnimation(AnimationController.PlayerStateTypes.None);
        }
    }

    /// <summary>
    /// Set the bool for a _jumpRequest to be true for when the player hits the space key/associated jump key in the input system
    /// </summary>
    public void Jump()
    {
        _jumpRequested = true;
    }

    /// <summary> Flips the player by inverting their scale to be negative or positive </summary>
    public void InvertPlayerDir()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }
}
