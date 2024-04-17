using System;
using UnityEngine;

[Serializable]
public class InventoryData
{
    public InventoryData(int slotCount)
    {
        Items = new Item[slotCount];
    }
    
    public Item[] Items { get; private set; }

    public bool SlotAvailable(Item itemToAdd)
    {
        foreach (var item in Items)
        {
            if (item.AvailableFor(itemToAdd)) return true;
        }

        return false;
    }

    public void AddItem(ref Item itemToAdd)
    {
        for (var i = 0; i < Items.Length; i++)
        {
            if (itemToAdd.Empty) return;
            
            if (Items[i].AvailableFor(itemToAdd))
            {
                Items[i].Merge(ref itemToAdd);
            }
        }
    }

    public Item Pick(int slotID)
    {
        if(slotID > Items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        var item = Items[slotID];
        Items[slotID] = new Item();

        return item;
    }

    public void Swap(int slotA, int slotB)
    {
        (Items[slotA], Items[slotB]) = (Items[slotB], Items[slotA]);
    }
}