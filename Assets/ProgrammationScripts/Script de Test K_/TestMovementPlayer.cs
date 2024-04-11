using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class TestMovementPlayer : MonoBehaviour
{
    [SerializeField] private GameObject head;
    [SerializeField] private float minSpeed = 4f;
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;
    //[SerializeField] private float jumpForce = 10;
    
    private float _headTilt = 0;
    private float speed;
    
    private CharacterController _characterController;

    private Vector3 _movementX;
    private Vector3 _movementZ;
    /*private Vector3 _moveUp = Vector3.zero;
    private Rigidbody _rigidbody;*/

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        //_rigidbody = GetComponent<Rigidbody>();
        speed = minSpeed;
    }

    private void Update()
    {
        var movement = (_movementX + _movementZ).normalized;

        _characterController.Move(Physics.gravity * Time.deltaTime);
        _characterController.Move(movement * (Time.deltaTime * speed));
        
        //Jump();

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }*/
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

    /*public void Jump(float jumpForce)
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }*/
}
