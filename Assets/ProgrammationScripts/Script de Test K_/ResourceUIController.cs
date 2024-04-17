using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUIController : MonoBehaviour
{
    public static ResourceUIController Instance { get; private set; }
    [SerializeField] private List<TextMeshProUGUI> textResource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void UpdateResourceUI(int index, int value)
    {
        textResource[index].text = value.ToString();
    }
}