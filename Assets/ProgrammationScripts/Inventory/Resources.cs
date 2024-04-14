using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Resources
{
    public static Resources Instance { get; private set; }

    [SerializeField] private int index;
    [SerializeField] private int maxValue;
    [SerializeField] private int value;
    [SerializeField] private int count;

    public void AddResource(int resourceToAdd)
    {
        value += resourceToAdd;

        if (value > maxValue) value = maxValue;
        ResourceUIController.Instance.UpdateResourceUI(index, value);
    }

    public bool RemoveResource(int resourceToRemove)
    {
        if (value - resourceToRemove < 0) return false;

        value -= resourceToRemove;
        ResourceUIController.Instance.UpdateResourceUI(index, value);
        return true;
    }

    public void Merge(ref Resources other)
    {
        if (Full) return;

        if (Empty) Data = other.Data;
        
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

    public bool AvailableFor(Resources other) => Empty || (Data == other.Data && !Full);
    
    public ResourceData Data { get; private set; }
    
    public bool Full => Data && count >= Data.stackMaxCount;

    public bool Empty => count == 0 || Data == null;

    public int Count => count;

}