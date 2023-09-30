using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int lives = 3;
    public int maxLives = 3;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.2f;
    public float canTakeDamageCounter;
    
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("Heart"))
        {
            if (lives >= maxLives) return;
            lives += 1;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Enemy"))
        {
            lives -= 1;
            if (lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }
    
    
}
