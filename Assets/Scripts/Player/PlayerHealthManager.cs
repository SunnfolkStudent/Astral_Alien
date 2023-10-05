using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int health = 3;
    public int maxHealth = 3;
    [HideInInspector] public bool hit = false;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.4f;
    public float canTakeDamageCounter;
    
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
        
        if (other.CompareTag("Heart"))
        {
            if (health >= maxHealth) return;
            health += 1;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Enemy"))
        {
            health -= 1;
            
            /*if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }*/

            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("TryAgain");
    }
    
}
