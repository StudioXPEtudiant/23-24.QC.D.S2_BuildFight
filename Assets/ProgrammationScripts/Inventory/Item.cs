using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct Item
{
    [SerializeField] private int count;
    [SerializeField] private ItemData data;
    
    public void Merge(ref Item other)
    {
        if (Full) return;
        
        if (Empty) data = other.Data;
        
        if (other.Data != Data) throw new System.Exception("Try to merge different types items.");

        var total = other.count + count;

        if (total <= Data.stackMaxCount)
        {
            count = total;
            other.count = 0;
            return;
        }

        count = Data.stackMaxCount;
        other.count = total - count;

    }
    public bool AvailableFor(Item other) => Empty || (Data == other.Data && !Full);
    public ItemData Data => data;
    public bool Full => Data && count >= Data.stackMaxCount;
    public bool Empty => count == 0 || Data == null;
    public int Count => count;
}