using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [SerializeField]
    private float _speed = 6.0f;
    [SerializeField]
    private float _jumpSpeed = 6.0f;
    [SerializeField]
    private float _gravity  = 6.0f;
     [SerializeField]
    private Vector3 _moveDirection = Vector3.zero;
     private bool _canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
         _characterController = GetComponent<CharacterController>();
         _canDoubleJump = false;

         if(_characterController == null)
         {
             Debug.Log("Character Controller is null");
         }
    }

    // Update is called once per frame
    void Update()
    {
        if (_characterController.isGrounded)
        {
            _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f,0.0f);
            _moveDirection *= _speed;

            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = _jumpSpeed;
                _canDoubleJump = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
        {
            _moveDirection.y += _jumpSpeed;
            _canDoubleJump = false;
        }
        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}

