using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float RunSpeed=5f;
    public float JumpHeight=5f;
    public LayerMask GroundMask;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private enum MovementState { Idel = 0, Run = 1, Jump =2 }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput =  Input.GetAxis("Horizontal");

        bool hasJumped = Input.GetButtonDown("Jump");

        Vector2 inputDirection;
        
        if (hasJumped && GroundCheck())
        {
            inputDirection = new Vector2(xInput * RunSpeed, JumpHeight);

        }
        else
        {
            inputDirection = new Vector2(xInput * RunSpeed, _rigidbody.velocity.y);
        }
        
        
        _rigidbody.velocity = inputDirection;

        UpdateAnimation(xInput);


    }
    private bool GroundCheck()
    {
        bool grounded = Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down, .1f, GroundMask);
        return grounded;
    }

    private void UpdateAnimation(float xInput)
    {
        MovementState current = MovementState.Idel;
        if (xInput > 0.01)
        {
            _spriteRenderer.flipX = false;
        }
        else if (xInput < -0.01)
        {
            _spriteRenderer.flipX = true;
        }

        if(!GroundCheck())
        {
           current = MovementState.Jump;
        }
        else if (xInput > 0.01 || xInput < -0.01)
        {
            current = MovementState.Run;
        }
        
        _animator.SetInteger("MovementState", (int)current);

    }
}
