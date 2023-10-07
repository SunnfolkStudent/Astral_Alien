using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            
            animationTimeCounter = Time.time + _animator.GetCurrentAnimatorClipInfo(0).Length;
        }

        private void FixedUpdate()
        {
            UpdateAnimation();

        }

        private void UpdateAnimation()
        {
            if (Time.time < animationTimeCounter) return;
            if (_healthManager.hit)
            {
                _animator.Play(_healthManager.health > 0 ? "hit" : "death");
                _healthManager.canTakeDamage = false;
               

                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("hit"))
                {
                    animationTimeCounter = Time.time + 0.18f;
                }
                else
                {
                    animationTimeCounter = Time.time +1;
                }
                _healthManager.hit = false;
            }
            else if (!_collision.IsPlayerGrounded())
            {
                _animator.Play(_rigidbody2D.velocity.y > 0 ? "jump" : "fall"); 
            }
            else
            {
               if ( _healthManager.hit)return;
                _animator.Play("run front");
            }
        }
    }  
}

