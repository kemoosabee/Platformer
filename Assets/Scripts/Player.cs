using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    private float _moveInput;
    private Rigidbody2D _rigidbody;
    private bool _facingRight = false;


    [SerializeField]
    private float _jumpSpeed = 2.0f;
    private int _extraJumps;
    private int _extraJumpValue = 1;
    [SerializeField]
    private Transform _groundCheck;
    private bool _isGrounded;
    [SerializeField]
    private float _checkRadius;
    [SerializeField]
    private LayerMask _whatIsGround;

    void Start()
    {
        _extraJumps = _extraJumpValue;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(_isGrounded)
        {
            _extraJumps = _extraJumpValue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && _extraJumps > 0)
        {
            _rigidbody.velocity = Vector2.up * _jumpSpeed;
            _extraJumps --;
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && _extraJumps == 0 && _isGrounded == true)
        {
             _rigidbody.velocity = Vector2.up * _jumpSpeed;
        }
    }

    void FixedUpdate()
    {
        ControlPlayerMovement();
    }

     void ControlPlayerMovement()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius,_whatIsGround);
        _moveInput = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);

        if(_facingRight == false && _moveInput > 0)
        {
            _facingRight = true;
             transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else if(_facingRight == true && _moveInput < 0)
        {
            _facingRight = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
}
