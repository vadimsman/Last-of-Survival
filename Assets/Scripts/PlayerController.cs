using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Private
    private CharacterController _characterController;

    private Vector3 _moveVector;

    private float _fallVelocity = 0;

    //Public
    public float Speed;

    public float Gravity = 9.8f;

    public float JumpForce;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        JumpMove();
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);
        FallAndJump();
    }

    private void JumpMove()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -JumpForce;
        }
    }

    private void FallAndJump()
    {
        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }

    private void Movement()
    {
        _moveVector = Vector3.zero;
        Speed = 5;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 8;
        }
    }
}
