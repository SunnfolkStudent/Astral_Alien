using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask whatIsGround;

    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        if (!IsGrounded()) return;
        _rigidbody2D.velocity = new Vector2(-transform.localScale.x * moveSpeed, _rigidbody2D.velocity.y);
    }

    private void LateUpdate()
    {
        if (!IsGrounded()) return;
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, 
            Vector2.down, 1.5f, whatIsGround);
    }
}
