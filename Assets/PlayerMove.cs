using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float MaxSpeed = 3f;
    [SerializeField] float Acceleration = 3.0f;

    float CurrentSpeed = 0.0f;

    private Rigidbody2D _rigidbody2D;
    Vector2 directionVector = Vector2.zero;
    Vector2 movementVector = Vector2.zero;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        directionVector = new Vector3();
    }

    void Update()
    {
        HandleInput();
        CalculateVelocity(Time.deltaTime);
    }
    
    private void HandleInput()
    {
        directionVector.x = Input.GetAxis("Horizontal");
        directionVector.y = Input.GetAxis("Vertical");
        directionVector.Normalize();
        
        //_movementVector *= speed;
        //_animator.SetFloat(Movement, Vector3.Magnitude(_movementVector));
    }

    void CalculateVelocity(float deltaTime)
    {
        movementVector += directionVector * (Acceleration * deltaTime);
        if (movementVector.magnitude > 1.0f)
            movementVector.Normalize();

        _rigidbody2D.velocity = movementVector;

        Debug.Log("RB Velocity: " + _rigidbody2D.velocity + "\nMovementVector: " + movementVector);

        if (_rigidbody2D.velocity.magnitude >= MaxSpeed)
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * MaxSpeed;
    }
}
