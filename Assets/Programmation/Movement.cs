using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 6f;
    
    public float jumpspeed = 8f;

    public float RotationSpeed = 60f;

    private Vector3 moveD = Vector3.zero;

    CharacterController Cac;

    void Start()
    {
       Cac = GetComponent<CharacterController>();  
    }

    void Update()
    {
        if(Cac.isGrounded){
            moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            if(Input.GetButton("Jump")){
                moveD.y = jumpspeed;
            }
        }
        moveD += Physics.gravity * Time.deltaTime;
        transform.Rotate (Vector3.up *Input.GetAxis("Mouse X")*Time.deltaTime * RotationSpeed);

        Cac.Move(moveD*Time.deltaTime);
    }

    void OnMouseDown()
    {
        Screen.lockCursor = true;
    }
}
