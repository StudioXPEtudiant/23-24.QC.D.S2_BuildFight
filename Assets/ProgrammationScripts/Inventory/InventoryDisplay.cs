using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryContextMenu contextMenu;
    
    private int _draggedSlotIndex;

    private InventorySystem _inventory;

    private Slot[] _slots;

    public int Initialize(InventorySystem inventory)
    {
        _slots = GetComponentsInChildren<Slot>();
        _inventory = inventory;

        contextMenu.Init(inventory);

        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].Initialized(this, i);
        }

        return _slots.Length;
    }

    public void UpdateDisplay(Item[] items)
    {
        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].UpdateDisplay(items[i]);
        }
    }

    #region Inputs

    public void ClickSlot(int index)
    {
        contextMenu.Select(index, _slots[index]);
    }
    
    public void DragSlot(int index) => _draggedSlotIndex = index;

    public void DropOnSlot(int index)
    {
        _inventory.SwapSlots(_draggedSlotIndex, index);
    }

    #endregion
}