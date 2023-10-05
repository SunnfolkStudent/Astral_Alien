using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    public float moveSpeed = 4f;
    public float jumpSpeed = 6f;
    private Vector2 _desiredVelocity;

    [Header("CoyoteTime")] 
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;

    [Header("JumpBuffer")] 
    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;

    [Header("ShootBuffer")] 
    public float shootBufferTime = 1f;
    public float shootBufferCounter;

    [Header("isGrounded")] 
    public LayerMask whatIsGround;

    [Header("Audio")] 
    
    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private InputManager _input;
    private CollisionManager _collision;
    
    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputManager>();
        _collision = GetComponent<CollisionManager>();
    }

    
    private void Update()
    {
        _desiredVelocity = _rigidbody2D.velocity;

        if (_collision.IsPlayerGrounded())
        { coyoteTimeCounter = coyoteTime; }
        else
        { coyoteTimeCounter -= 1 * Time.deltaTime; }

        if (_input.jumpPressed)
        { jumpBufferCounter = jumpBufferTime; }
        else
        { jumpBufferCounter -= 1 * Time.deltaTime; }

        if (_input.shootPressed)
        { shootBufferCounter = shootBufferTime; }
        else
        { shootBufferCounter -= 1 * Time.deltaTime; }

        //Jumping
        if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        {
            _desiredVelocity.y = jumpSpeed;
            jumpBufferCounter = 0f;
        }

        /*
        if (_input.jumpReleased && _rigidbody2D.velocity.y > 0f)
        {
            _desiredVelocity.y *= 0.5f;
            coyoteTimeCounter = 0f;
        }
        */
        _rigidbody2D.velocity = _desiredVelocity;
        
        //Shooting
        if (shootBufferCounter > 0)
        {
            shootBufferCounter = 0f;
        }
        
        
    }

    private void FixedUpdate()
    {
        
        _rigidbody2D.velocity = new Vector2(_input.moveDirection.x * moveSpeed, _rigidbody2D.velocity.y);
        
    }

    
}
