using System;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryContextMenu _contextMenu;
    
    private int _draggedSlotIndex;

    private InventorySystem _inventorySystem;

    private Slot[] _slots;

    public int Initialize(InventorySystem inventory)
    {
        _slots = GetComponentsInChildren<Slot>();
        _inventorySystem = inventory;

        _contextMenu.Init(inventory);

        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].Initialized(this, i);
        }

        return _slots.Length;
    }

    public void UpdateDisplay(Resources[] items)
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].UpdateDisplay(items[i]);
        }
    }

    #region Inputs

    public void ClickSlot(int index)
    {
        _contextMenu.Select(index, _slots[index]);
    }
    
    public void DragSlot(int index) => _draggedSlotIndex = index;

    public void DropOnSlot(int index)
    {
        _inventorySystem.SwapSlots(_draggedSlotIndex, index);
    }

    #endregion
}