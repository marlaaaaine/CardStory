
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpd = 5f, _jumpforce = 5f; 
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private AnimationController _animController;
    private Vector2 _moveVector;
    private bool _jumpRequested = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigidBody.linearVelocityX = _moveVector.x * _movementSpd;
        if(_jumpRequested)
        {
            _rigidBody.linearVelocityY = _jumpforce;
            _jumpRequested = false;
        }
    }

    public void Move(Vector2 moveVector)
    {   
        var dot = Vector2.Dot(moveVector, _moveVector);
        if(dot == -1)
        {
            InvertFaceDir(false);
        } else
        {
            InvertFaceDir(true);
        }
        _moveVector = moveVector;
        // play the move anim if the player has moved
        if(_moveVector == Vector2.zero) // no movement if movement = 0
        {
           _animController.SetAnimation(false);
        } else // movement != 0, player is moving
        {
          _animController.SetAnimation(true);  
        }

    }

    public void Jump()
    {
        _jumpRequested = true;
    }

    public void InvertFaceDir(bool facingFront)
    {
        if(!facingFront)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, -180, 0);
        } 
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
