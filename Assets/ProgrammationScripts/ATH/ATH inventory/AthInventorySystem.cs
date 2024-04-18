using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthInventorySystem : MonoBehaviour
{
    [SerializeField] private AthInventoryDisplay display;
    private AthInventoryData _data;
    
    public static AthInventorySystem Instance { get; private set; }

    private void Awake()
    {
        var slotCount = display.InitializeAth(this);

        _data = new AthInventoryData(slotCount);
        
        display.UpdateDisplay(_data.Items);

        Instance = this;
    }

    public void AddItemToAth(Item item)
    {
        if (!_data.SlotAvailableForAth(item)) return;

        _data.AddItemAth(ref item);

        display.UpdateDisplay(_data.Items);
    }

    public void PickItemToAth(int slotID)
    {
        var result = _data.PickAth(slotID);
        
        display.UpdateDisplay(_data.Items);
    }

    public Item[] Data => _data.Items;
}