using System;

[Serializable]
public class AthInventoryData
{
    public AthInventoryData(int slotCount)
    {
        Items = new Item[slotCount];
    }
    
    public Item[] Items { get; private set; }

    public bool SlotAvailableForAth(Item itemToAdd)
    {
        foreach (var item in Items)
        {
            if (item.AvailableFor(itemToAdd)) return true;
        }

        return false;
    }

    public void AddItemAth(ref Item itemToAdd)
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

    public Item PickAth(int slotID)
    {
        if(slotID > Items.Length) throw new System.Exception($"Id {slotID} out of inventory");

        var item = Items[slotID];
        Items[slotID] = new Item();

        return item;
    }

    /*public void Swap(int slotA, int slotB)
    {
        (Items[slotA], Items[slotB]) = (Items[slotB], Items[slotA]);
    }*/
}