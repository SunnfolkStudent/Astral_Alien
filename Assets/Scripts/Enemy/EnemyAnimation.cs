using System;
using Enemy;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private EnemyHealthManager _healthManager;
    public float animationTimeCounter;
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _healthManager = GetComponent<EnemyHealthManager>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        UpdateAnimation();
    }


    private void UpdateAnimation()
    {
        
        
        if (_healthManager.hit)
        {
            _animator.Play(_healthManager.health != 0 ? "hit" : "death");
            animationTimeCounter = Time.time + _animator.GetCurrentAnimatorClipInfo(0).Length;
            print("Im Animating!: " + Time.time);
            _healthManager.hit = false;
        }
        else
        {
            if (Time.time < animationTimeCounter) return;
            _animator.Play("walk");
            print("Im not hit");
        }
    }
}
