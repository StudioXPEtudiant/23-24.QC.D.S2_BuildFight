using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct Resources
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

    
}