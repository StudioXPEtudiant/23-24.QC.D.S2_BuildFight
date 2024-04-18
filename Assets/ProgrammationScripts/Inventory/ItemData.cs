using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName;

    [SerializeField] public int stackMaxCount = 10;

    [SerializeField] public Sprite icon;
}