using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6.0f;
    [SerializeField]
    private float _jumpSpeed = 6.0f;
    [SerializeField]
    private float _moveInput;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);
    }
}

