using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventoryUI : MonoBehaviour
{
    private InventorySystem _inventory;
    private AthInventorySystem _athInventory;

    private void Awake()
    {
        _inventory = GetComponentInChildren<InventorySystem>();
        _athInventory = FindObjectOfType<AthInventorySystem>();
    }
    
    private void Start()
    {
        _inventory.gameObject.SetActive(false);
    }

    public void OpenInterface()
    {
        _athInventory.gameObject.SetActive(false);
        _inventory.gameObject.SetActive(true);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseInterface()
    {
        _inventory.gameObject.SetActive(false);
        _athInventory.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
