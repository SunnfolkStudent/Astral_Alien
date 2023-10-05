using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private PlayerHealthManager _healthManager;
        private CollisionManager _collision;
        private InputManager _input;
        
        public float animationTimeCounter;
        
        
        
        
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _healthManager = GetComponent<PlayerHealthManager>();
            _collision = GetComponent<CollisionManager>();
            _input = GetComponent<InputManager>();
        }

        private void FixedUpdate()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {

            if (_healthManager.hit)
            {
                _animator.Play(_healthManager.health);
                _healthManager.canTakeDamage = false;
                animationTimeCounter = Time.time + _animator.GetCurrentAnimatorClipInfo(0).Length;
            }
            else if (!_collision.IsPlayerGrounded())
            {
                _animator.Play(_rigidbody2D.velocity.y > 0 ? "jump" : "fall"); 
                
            }
            else
            {
                if (Time.time < animationTimeCounter) return;
                _animator.Play("run front");
            }
        }
    }  
}

