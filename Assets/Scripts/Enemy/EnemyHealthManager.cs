using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyHealthManager : MonoBehaviour
    {
        public int minHealth = 6;
        public int maxHealth = 18;
        [HideInInspector] public int health;
        [HideInInspector] public bool hit = false; 

        private void Start()
        {
            health = Random.Range(minHealth, maxHealth);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Bullet"))
            {
                hit = true;
                print("Im hit: "+ Time.time);
                TakeDamage(other.GetComponent<Bullet>().damage);
            }
        }
    
        public void TakeDamage(int damage)
        {
            health -= damage;
            //hit = false;
        
            /*if (health <= 0)
        {
            Die();
        }*/
        
        }

        private void Die()
        {
            Destroy(gameObject);
        }

    
    }
}
