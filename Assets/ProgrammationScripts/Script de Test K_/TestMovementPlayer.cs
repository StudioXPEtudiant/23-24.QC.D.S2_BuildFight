using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class TestMovementPlayer : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private float minSpeed = 4;
    [SerializeField] private float maxSpeed = 6;
    [SerializeField] private float minRotation = -90;
    [SerializeField] private float maxRotation = 90;
    [SerializeField] private float jumpSpeed = 8;

    private float _headTilt = 0;
    private float speed;
    
    private CharacterController _characterController;

    private Vector3 _movementX;
    private Vector3 _movementZ;
    private Vector3 _movementY = Vector3.zero;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>(); 
        speed = minSpeed;
    }

    private void Update()
    {
        Vector3 movement = (_movementX + _movementZ).normalized;

        _characterController.Move(Physics.gravity * Time.deltaTime);
        _characterController.Move(movement * (Time.deltaTime * speed));
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
        /*if (!_characterController.isGrounded) return;
        
        _movementY = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _movementY = transform.TransformDirection(_movementY);
        _movementY *= speed;
        
        _movementY.y = jumpSpeed;
        
        _movementY += Physics.gravity * Time.deltaTime;*/
    }
}
