using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector3 _movementVector;
    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movementVector = new Vector3();
    }

    // Update is called once per frame
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
        
        _movementVector *= speed;
        

        //_animator.SetFloat(Movement, Vector3.Magnitude(_movementVector));
        _rigidbody2D.velocity = _movementVector;
    }
    
    private void FlipSprite()
    {
        var runningHorizontally = Mathf.Abs(_rigidbody2D.velocity.x) > Mathf.Epsilon;

        if (runningHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x), 1);
        }
    }
}
