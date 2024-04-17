using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventoryUI : MonoBehaviour
{
    private InventorySystem _inventory;
    private CharacterController _character;

    private void Awake()
    {
        _inventory = GetComponentInChildren<InventorySystem>();
        _character = FindObjectOfType<CharacterController>();
    }
    
    private void Start()
    {
        _inventory.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenInterface();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInterface();
        }
    }

    public void OpenInterface()
    {
        _inventory.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInterface()
    {
        _inventory.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
