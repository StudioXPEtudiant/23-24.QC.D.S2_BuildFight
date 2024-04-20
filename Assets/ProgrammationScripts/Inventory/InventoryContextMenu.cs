using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryContextMenu : MonoBehaviour
{
    [SerializeField] private Button dropButton, closeButton;

    private InventorySystem _inventorySystem;
    private AthInventorySystem _athInventory;
    private PickableFunction _pickable;

    private int _targetSlotID;

    private void Awake()
    {
        dropButton.onClick.AddListener(Drop);
        closeButton.onClick.AddListener(Close);

        _pickable = FindObjectOfType<PickableFunction>();
    }

    public void Init(InventorySystem inventory)
    {
        _inventorySystem = inventory;
    }

    public void InitAth(AthInventorySystem athInventory)
    {
        _athInventory = athInventory;
    }

    public void Select(int slotID, Slot slot)
    {
        var slotItem = _inventorySystem.Data[slotID];
        if (slotItem.Empty)
        {
            Close();
            return;
        }
        
        gameObject.SetActive(true);
        transform.position = slot.transform.position;

        _targetSlotID = slotID;
    }

    #region Inouts

    private void Drop()
    {
        _inventorySystem.PickItem(_targetSlotID);
        _athInventory.PickItemToAth(_targetSlotID);
        _pickable.Drop();
        Close();
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    #endregion
}