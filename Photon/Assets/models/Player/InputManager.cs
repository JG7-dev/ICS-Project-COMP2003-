using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerInput.PlayerControllerActions _playerControllerActions;
    private PlayerMotor _motor;
    private PlayerLook _look;
    
    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = new PlayerInput();
        _playerControllerActions = _playerInput.PlayerController;
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _motor.ProcessMove(_playerControllerActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        _look.ProcessLook(_playerControllerActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _playerControllerActions.Enable();
    }

    private void OnDisable()
    {
        _playerControllerActions.Disable();
    }
}
