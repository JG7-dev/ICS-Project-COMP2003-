using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Shooting _gun;
    private PlayerInput _playerInput;
    public PlayerInput.OnFootActions _onFootActions;
    private Shooting _shooting;
    private PlayerMotor _motor;
    private PlayerLook _look;
    

    // Start is called before the first frame update


    void Awake()
    {
        _playerInput = new PlayerInput();
        _onFootActions = _playerInput.OnFoot;
        _motor = GetComponent<PlayerMotor>();
        _look = GetComponent<PlayerLook>();
        
        _onFootActions.Shoot.performed += _ => _shooting.Shoot();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _motor.ProcessMove(_onFootActions.Movement.ReadValue<Vector2>());
        
    }

    private void LateUpdate()
    {
        
        _look.ProcessLook(_onFootActions.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _onFootActions.Enable(); 
    }

    private void OnDisable()
    {
        
        _onFootActions.Disable();
       
    }
}
