using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Permet de gérer les quêtes
/// </summary>
public class SimpleGameFlagCollection : MonoBehaviour
{
    public static SimpleGameFlagCollection Instance { get; private set; }
    private readonly List<string> _flags = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Triggers(string flag)
    {
        if(string.IsNullOrEmpty(flag)) return;
        
        if(!_flags.Contains(flag))
            _flags.Add(flag);
    }

    public bool IsTriggered(string flag)
    {
        return !string.IsNullOrEmpty(flag) && _flags.Contains(flag);
    }
}
