using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpspeed = 8f;
    public float RotationSpeed = 120f;
    public float verticalRotationLimit = 80f;
    public float range;
    public LayerMask layermask;

    private Vector3 moveD = Vector3.zero;
    private float verticalRotation = 0f;

    CharacterController Cac;

    void Start()
    {
        Cac = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Cac.isGrounded)
        {
            moveD = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            if (Input.GetButton("Jump"))
            {
                moveD.y = jumpspeed;
            } 
        }

        moveD += Physics.gravity * Time.deltaTime;


        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeed);


        verticalRotation -= Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        Cac.Move(moveD * Time.deltaTime);

      
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Vérifie si le joueur clique sur le PNJ
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range, layermask))
            {
                if (hit.collider.gameObject.CompareTag("PNJ"))
                {
                    // Affiche le dialogue
                    //something
                    hit.collider.gameObject.GetComponent<Dialogue>().ShowDialogue();
                }
            }
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * range, Color.blue);
    }
}