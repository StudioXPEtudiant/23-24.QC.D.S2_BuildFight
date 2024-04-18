using UnityEngine;

public class AthInventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryContextMenu contextMenu;
    
    private int _draggedSlotIndex;

    private AthInventorySystem _athInventory;

    private Slot[] _slots;

    
    public int InitializeAth(AthInventorySystem inventory)
    {
        _slots = GetComponentsInChildren<Slot>();
        _athInventory = inventory;

        contextMenu.InitAth(inventory);

        for (var i = 0; i < _slots.Length; i++)
        {
            _slots[i].InitializedAth(this, i);
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
}