using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private EnemyHealthManager _healthManager;
    
    
    
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
        UpdateAnimation();
    }


    private void UpdateAnimation()
    {
        if (_healthManager.hit == true)
        {
            _animator.Play(_healthManager.health != 0 
                ? "hit" : "death");
        }
        else
        {
            _animator.Play("walk");
        }
    }
}
