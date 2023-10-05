using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    [Header("isGrounded")] 
    public LayerMask whatIsGround;

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Win");
        }*/
    }

    public bool IsPlayerGrounded()
    {
        return Physics2D.Raycast(transform.position,Vector2.down, 0.5f, whatIsGround);
    }
}
