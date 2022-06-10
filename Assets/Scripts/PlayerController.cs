using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool _LeftIsPressed, _RightIsPressed, _FireIsPressed;
    private Rigidbody2D _rb;

    [SerializeField] private int _Strength;
    [SerializeField] private GameObject _Bullet;
    [SerializeField] Transform _BulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_Bullet, _BulletSpawn.position, quaternion.identity);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void OnLeftMovement(InputValue inputValue)
    {
        _LeftIsPressed = inputValue.isPressed;
        Debug.Log("Left is " + inputValue.isPressed);
    }
    
    void OnRightMovement(InputValue inputValue)
    {
        _RightIsPressed = inputValue.isPressed;
        Debug.Log("Right is " + inputValue.isPressed);
    }

    private void Move()
    {
        if (_LeftIsPressed)
        {
            _rb.velocity = (-transform.right) * _Strength;
        }
        else if (_RightIsPressed)
        {
            _rb.velocity = transform.right * _Strength;
        }
        else if (!_RightIsPressed && !_LeftIsPressed)
        {
            _rb.velocity = transform.right * 0;
        }
    }
}