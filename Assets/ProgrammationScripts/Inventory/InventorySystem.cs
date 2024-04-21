using System;
using UnityEngine;
using UnityEngine.Serialization;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;
    [SerializeField] private AthInventoryDisplay athDisplay;
    [SerializeField] private int size = 13;
    
    private InventoryData _data;

    private GameObject[] _slots;
    private int _currentSlot;
    
    public static InventorySystem Instance { get; private set; }

    private void Awake()
    {
        var slotCount = display.Initialize(this);
        _data = new InventoryData(slotCount);
        display.UpdateDisplay(_data.Items);

        _slots = new GameObject[size];
        
        Instance = this;
    }

    public Item AddItem(Item item)
    {
        if (!_data.SlotAvailable(item)) return item;

        _data.AddItem(ref item);

        display.UpdateDisplay(_data.Items);
        
        return item;
    }

    public Item PickItem(int slotID)
    {
        var result = _data.Pick(slotID);
        
        display.UpdateDisplay(_data.Items);

        return result;
    }

    public void SwapSlots(int slotA, int slotB)
    {
        _data.Swap(slotA, slotB);

        display.UpdateDisplay(_data.Items);
        athDisplay.UpdateDisplay(_data.Items);
    }
    
    /*public bool TrySetItemInEmptySlot(GameObject item)
    {
        if (_slots[_currentSlot])
            return false;

        _slots[_currentSlot] = item;
        return true;
    }*/
    public Item[] Data => _data.Items;
}