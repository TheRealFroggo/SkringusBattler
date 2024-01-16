using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Rigidbody2D)))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _movementVector;
    private Animator _animator;
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Movement = Animator.StringToHash("Movement");
    private static readonly int Hurt = Animator.StringToHash("Hurt");
    private const float CharacterScale = 2.5f;

    [SerializeField] private float speed = 3f;
    [SerializeField] public int health = 1000;
    private static readonly int Attack = Animator.StringToHash("Attack");

    //TODO Animation state machine 
    //TODO Stop Movement while attacking (or not? depends. Needs state machine)
    //TODO Make orb take hits
    //TODO Obstacles / nav mesh for enemy 
    
    private bool IsDead => health == 0;
    private bool IsAttacking => Input.GetKeyDown(KeyCode.Space);
    
    
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementVector = new Vector3();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Insert revival condition here
        if (IsDead) return;

        if (IsAttacking) SwordSlash();
            
        PlayerMovement();
        FlipSprite();
    }
    
    private void FlipSprite()
    {
        var runningHorizontally = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

        if (runningHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x)*CharacterScale, CharacterScale);
        }
    }

    private void PlayerMovement()
    {
        _movementVector.x = Input.GetAxisRaw("Horizontal");
        _movementVector.y = Input.GetAxisRaw("Vertical");
        _movementVector = Vector3.Normalize(_movementVector);
        
        _movementVector *= speed;
        

        _animator.SetFloat(Movement, Vector3.Magnitude(_movementVector));
        _rigidbody2D.velocity = _movementVector;
    }
    
    private void Die()
    {
        _animator.SetTrigger(Death);
        _rigidbody2D.velocity = Vector3.zero;
    }

    private void SwordSlash()
    {
        _animator.SetTrigger(Attack);
        
    }
    
    //public functions VVVVV
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
            health = 0;
        if (IsDead)
            Die();
        else
        {
            _animator.SetTrigger(Hurt);
            
        }
        
    }
}
