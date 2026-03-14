using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;

    private Vector3 _input, _moveDirection;

    [Header("Variables that affect the player's movement")]
    public float MoveSpeed = 10;
    public float JumpHeight = 10;
    public float Gravity = 9.81f;
    public float AirControl = 10; // will allow us to set the speed

    [Header("Sound Effects")]
    public AudioClip JumpSFX;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // if you have an xbox controller and use joystick to move player
        // then this method will recognize that input and you will be able to
        // use that controller. makes function more generic rather than
        // limiting to keyboard

        _input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;
        // based on local orientation (updating based on input from the user)
        // input is a Vector3

        // diagonal movement is a bit faster than just pressing one key because of the multiplication
        // normalize the input vector to solve this problem

        _input *= MoveSpeed;

        if(_controller.isGrounded)
        {
            // we can jump if we are grounded
            Jump();
        } 
        else
        {
            // handle the player coming back down after jumping
            AfterJump();
        }

        _moveDirection.y -= Gravity * Time.deltaTime;
        // we are doing this because we want to move the object down (down vector)
        // going to subtract from the y component over time

    }

    private void Jump()
    {
        _moveDirection = _input;
        // we can jump if we are grounded
        if(Input.GetButton("Jump"))
        {
            _moveDirection.y = Mathf.Sqrt(2 * JumpHeight * Gravity);
            if(JumpSFX != null){AudioSource.PlayClipAtPoint(JumpSFX, Camera.main.transform.position);}
        } 
        else
        {
            _moveDirection.y = 0.0f;
        }
    }

    private void AfterJump()
    {
        // we are midair; we should not be able to jump
        _input.y = _moveDirection.y; // we do not want to change the y height
        _moveDirection = Vector3.Lerp(_moveDirection, _input, AirControl * Time.deltaTime);
        // we want to gradually change the player's direction while in air 
        // abt preserving current height (there will be an arc because applying from height)        
    }
}
