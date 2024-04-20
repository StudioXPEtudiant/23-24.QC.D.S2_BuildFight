using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthInventorySystem : MonoBehaviour
{
    [SerializeField] private AthInventoryDisplay display;
    [SerializeField] private int size = 13;

    private AthInventoryData _data;

    private GameObject[] _slots;
    private int _currentSlot;

    private void Awake()
    {
        var slotCount = display.InitializeAth(this);

        _data = new AthInventoryData(slotCount);
        
        display.UpdateDisplay(_data.Items);
        display.UpdateDisplayAth(_data.Items);

        _slots = new GameObject[size];
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

    public GameObject GetCurrentItem()
    {
        return _slots[_currentSlot];
    }

    public void Select(int slotID)
    {
        if(slotID >= size)
        {
            slotID = 1;
        }
        else if(slotID < 0)
        {
            slotID = size - 1;
        }

        if(slotID == _currentSlot) return;

        var currentInteractable = GetCurrentItem();
        if(currentInteractable)
            display.UpdateDisplayAth(_data.Items);

        _currentSlot = slotID;
        display.UpdateDisplayAth(_data.Items);

    }

    public void NextSlot()
    {
        Select(_currentSlot + 1);
        Debug.Log("Tu possede l'item" + (_currentSlot) + "dans les mains");
    }

    public Item[] Data => _data.Items;
}
