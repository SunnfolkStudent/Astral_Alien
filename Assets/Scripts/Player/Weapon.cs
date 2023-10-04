using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private InputManager _input;
    
    private void Start()
    {
        _input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_input.shootPressed)
        {
            Shoot();       
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
