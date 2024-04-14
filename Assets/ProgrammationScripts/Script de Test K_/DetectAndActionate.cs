using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layers;
    
    private NPCDialogueCollection _collection;
    private InventorySystem _inventorySystem;

    private RaycastHit _hit;
    
    //Quand je joueur clique sur le bouton gauche de la souris
    public void ActionateObjectFirstAction()
    {
        if(Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out _hit, distance)) return;

        _collection = _hit.collider.GetComponent<NPCDialogueCollection>();

        if (_collection) 
            _collection.Execute();
    }

    public void OpenInventoryInterface()
    {
        _inventorySystem.Open();
    }

    public void Escape()
    {
        _inventorySystem.Close();
    }
}
