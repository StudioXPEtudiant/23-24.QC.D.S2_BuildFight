using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Item itemToPush, pickedItem;

    private InventorySystem _inventorySystem;
    
    private void Awake()
    {
        _inventorySystem = FindObjectOfType<InventorySystem>();
        Add();
    }

    [ContextMenu("Push")]
    private void Add()
    {
        itemToPush = _inventorySystem.AddItem(itemToPush);
    }

    [ContextMenu("PickItem")]
    private void Pick()
    {
        pickedItem = _inventorySystem.PickItem(1);
    }
}
