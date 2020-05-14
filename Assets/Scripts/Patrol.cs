﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float _speed = 1.0f;
    private float _distance = 1.0f;
    private float _attackRange = 1.0f;

    private bool _movingRight = true;
    [SerializeField]
    private Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, _distance);
        if(groundInfo.collider == false)
        {
            if(_movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                _movingRight = false;
            }else{
                transform.eulerAngles = new Vector3(0, 0, 0);
                _movingRight = true;
            }
        }
        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        if(_movingRight == true)
        {
            RaycastHit2D lookForPlayer = Physics2D.Raycast(transform.position, Vector2.right, _attackRange);
             if(lookForPlayer.collider)
            {
                OnTriggerEnter2D(lookForPlayer.collider);
            }
        }
        else
        {
            RaycastHit2D lookForPlayer = Physics2D.Raycast(transform.position, Vector2.left, _attackRange);
            if(lookForPlayer.collider)
            {
                OnTriggerEnter2D(lookForPlayer.collider);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.name == "Player")
        {
            Debug.Log("Found Player");
        }
    }
}
