using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 2;
    public Rigidbody2D rigidbody;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }
    
    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
