using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] float BaseMoveSpeed = 3f;
    [Header("Current Stats")]
    [SerializeField] float CurrentMoveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _movementVector;
    
    public bool isMoving;
    
    void Start()
    {
        CurrentMoveSpeed = BaseMoveSpeed;

        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementVector = new Vector3();
    }

    void Update()
    {
        PlayerMovement();
        FlipSprite();
    }
    
    private void PlayerMovement()
    {
        _movementVector.x = Input.GetAxisRaw("Horizontal");
        _movementVector.y = Input.GetAxisRaw("Vertical");
        _movementVector = Vector3.Normalize(_movementVector);
        
        _movementVector *= CurrentMoveSpeed;
        
        //_animator.SetFloat(Movement, Vector3.Magnitude(_movementVector));
        isMoving = !(_movementVector == Vector3.zero);
            
        _rigidbody2D.velocity = _movementVector;
    }
    
    private void FlipSprite()
    {
        var runningHorizontally = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

        if (runningHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1);
    }
    public float GetBaseMaxHealthRegen()
    {
        return BaseMoveSpeed;
    }

    public void SetNewCurrentSpeed(float i)
    {
        CurrentMoveSpeed = i;
        Debug.Log("New Move Speed: " + CurrentMoveSpeed);
    }
}