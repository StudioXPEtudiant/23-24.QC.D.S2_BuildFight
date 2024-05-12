using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Permet de gérer les déplacements du joueur
/// </summary>
public class TestMovementPlayer : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private float minSpeed = 4f;
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f; 
    [SerializeField] private float jumpSpeed = 10;
    
    private float _headTilt = 0;
    private float _speed;
    private bool _isJumping;
    
    private CharacterController _characterController;

    private Vector3 _movementX;
    private Vector3 _movementZ;
    private Vector3 _velocity;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _speed = minSpeed;
    }

    private void Update()
    {
        var movement = (_movementX + _movementZ).normalized;
        movement *= Time.deltaTime * _speed;
        _velocity.x = movement.x;
        _velocity.z = movement.z;
        
        if (_characterController.isGrounded && _isJumping)
        {
            _velocity.y = jumpSpeed;
            _isJumping = false;
        }
        
        _velocity.y += Physics.gravity.y * Time.deltaTime;
        if (_characterController.isGrounded && _velocity.y < 0) _velocity.y = 0;
        _characterController.Move(_velocity * Time.deltaTime);
    }
    
    public void TiltHead (float mouseYValue)
    {
        _headTilt -= mouseYValue;
        head.transform.localRotation = Quaternion.Euler(_headTilt, 0, 0);

        if(_headTilt > maxRotation)
        {
            _headTilt = maxRotation;
        }
        if(_headTilt < minRotation)
        {
            _headTilt = minRotation;
        }
    }

    public void RotateY(float mouseXValue)
    {
        transform.Rotate(0, mouseXValue, 0);
    }

    public void SetMovementX(float horizontalValue)
    {
        _movementX = transform.right * horizontalValue;
    }

    public void SetMovementZ(float verticalValue)
    {
        _movementZ = transform.forward * verticalValue;
    }

    public void Jump()
    {
        if (_characterController.isGrounded)
        {
            _isJumping = true;
        }
    }
    
}
