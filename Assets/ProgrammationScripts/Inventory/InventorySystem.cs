using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private InventoryDisplay display;

    private InventoryData _data;
    
    public static InventorySystem Instance { get; private set; }

    private void Awake()
    {
        var slotCount = display.Initialize(this);

        _data = new InventoryData(slotCount);
        
        display.UpdateDisplay(_data.Items);

        Instance = this;
    }

    public Resources AddItem(Resources item)
    {
        if (!_data.SlotAvailable(item)) return item;

        _data.AddItem(ref item);

        display.UpdateDisplay(_data.Items);
        return item;
    }

    public Resources PickItem(int slotID)
    {
        var result = _data.Pick(slotID);
        
        display.UpdateDisplay(_data.Items);

        return result;
    }

    public void SwapSlots(int slotA, int slotB)
    {
        _data.Swap(slotA, slotB);

        display.UpdateDisplay(_data.Items);
    }

    public Resources[] Data => _data.Items;
}