using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Vector3 _playerVelocity;
    [SerializeField] private float _speed = 5f, _gravity = -9.81f;
    [SerializeField] private bool isGrounded;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = _controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(moveDirection) * _speed * Time.deltaTime);
        _playerVelocity.y += _gravity * Time.deltaTime;
        if (isGrounded&& _playerVelocity.y<0)
        {
            _playerVelocity.y = -2f;
        }
        _controller.Move(_playerVelocity * Time.deltaTime);
        //Debug.Log(_playerVelocity.y);
    }
}
