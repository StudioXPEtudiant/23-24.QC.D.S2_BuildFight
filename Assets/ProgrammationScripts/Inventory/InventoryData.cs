using System;
using System.Linq;
using UnityEngine;

public class InventoryData
{
    public InventoryData(int slotCount)
    {
        Items = new Resources[slotCount];
    }
    
    public Resources[] Items { get; private set; }

    public bool SlotAvailable(Resources itemToAdd)
    {
        return Items.Any(item => item.AvailableFor(itemToAdd));
    }

    public void AddItem(ref Resources itemToAdd)
    {
        foreach (var t in Items)
        {
            if(itemToAdd.Empty) return;
            
            if(t.AvailableFor(itemToAdd)) t.Merge(ref itemToAdd);
        }
    }

    public Resources Pick(int slotID)
    {
        if(slotID > Items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        var item = Items[slotID];
        Items[slotID] = new Resources();

        return item;
    }

    public void Swap(int slotA, int slotB)
    {
        (Items[slotA], Items[slotB]) = (Items[slotB], Items[slotA]);
    }
}