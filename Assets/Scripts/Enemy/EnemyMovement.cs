using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public LayerMask whatIsGround;
    public Camera playerCamera;
    public float distance = 11f;
    
    private Rigidbody2D _rigidbody2D;
    private float _difference;
    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    
    private void FixedUpdate()
    {
        _difference = transform.position.x - playerCamera.transform.position.x;
        if (!IsGrounded()) return; 
        if (_difference < distance)
        {
            _rigidbody2D.velocity = new Vector2(-transform.localScale.x * moveSpeed, _rigidbody2D.velocity.y);
        }
        
        
        
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
