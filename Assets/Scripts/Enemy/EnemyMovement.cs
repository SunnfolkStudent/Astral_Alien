using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float raycastDistance = 5f;
    public LayerMask whatIsGround;
    
    private float _startSpeed = 0f;
    private Rigidbody2D _rigidbody2D;
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }
    
    private void FixedUpdate()
    {
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = transform.right;

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);
        if (hit.collider.CompareTag("MainCamera"))
        {
            _startSpeed = moveSpeed;
        }
        
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
