using System;
using UnityEngine;

public class ResourceData : ScriptableObject
{
    [SerializeField] public string itemName;

    [SerializeField] public int stackMaxCount = 1;

    [SerializeField] public Sprite icon;
}