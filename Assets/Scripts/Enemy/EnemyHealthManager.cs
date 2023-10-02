using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealthManager : MonoBehaviour
{
    public int minHealth = 6;
    public int maxHealth = 18;
    private int health;

    private void Start()
    {
        health = Random.Range(minHealth, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    
}
