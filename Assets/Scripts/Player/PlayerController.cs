﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public UnityEngine.GameObject GamePlayUI;

    public UnityEngine.GameObject PauseMenuUI;

    public bool IsSettingsOpen;

    public float Stamina;

    public float StaminaExpenditure;

    public float StaminaRefresh;

    public Slider StaminaBar;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Movement();
        JumpMove();
        PauseMenuUpdate();
        StaminaBarUpdate();
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

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            Speed = 8;
            Stamina -= StaminaExpenditure * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Stamina += StaminaRefresh * Time.deltaTime;
        }

        if (Stamina > 100)
        {
            Stamina = 100;
        }

        //_moveVector = Vector3.ClampMagnitude(_moveVector, Speed);
    }

    private void PauseMenuUpdate()
    {
        if (Input.GetKey(KeyCode.Escape) && !IsSettingsOpen)
        {
            GamePlayUI.SetActive(false);
            PauseMenuUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    public void StaminaBarUpdate()
    {
        StaminaBar.value = Stamina;
    }
}
