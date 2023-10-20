using UnityEngine;

namespace Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody2D;
        private EnemyHealthManager _healthManager;
        private EnemyMovement _movement;
        public float animationTimeCounter;
    
        // Start is called before the first frame update
        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _healthManager = GetComponent<EnemyHealthManager>();
            _movement = GetComponent<EnemyMovement>();
        }
    
        private void Update()
        {
            UpdateAnimation();
        }


        private void UpdateAnimation()
        {
            if (Time.time < animationTimeCounter) return;
            
            if (_healthManager.hit)
            {
                _movement.canMove = false;
                //_animator.Play(_healthManager.health > 0  ? "hit" : "death");
                if (_healthManager.health > 0)
                {
                    _animator.Play("hit");
                    _healthManager.hit = false;
                    animationTimeCounter = Time.time + 0.4f;
                } 
                else if (_healthManager.health <= 0)
                {
                    _animator.Play("death");
                }

                
                
            }
            else
            {
               // if (Time.time < animationTimeCounter) return;
                _movement.canMove = true;
                _animator.Play("walk");
                //print("Im not hit");
            }
        }
    }
}

