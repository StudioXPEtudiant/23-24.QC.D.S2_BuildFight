using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float distance;
    //[SerializeField] private LayerMask layers;

    private OpenInventoryUI _inventoryUI;
    private AthInventorySystem _athInventory;
    
    private NPCDialogueCollection _collection;
    
    private PickableFunction _pickableFunction;

    private RaycastHit _hit;
    
    void Awake()
    {
        _inventoryUI = FindObjectOfType<OpenInventoryUI>();
        _athInventory = FindObjectOfType<AthInventorySystem>();
    }
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

    public void InteractObject()
    {
        if (Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(!Physics.Raycast(ray, out _hit, 5)) return;

        _pickableFunction = _hit.collider.GetComponent<PickableFunction>();
        if(_pickableFunction)
        {
            _pickableFunction.Pick();
        }

        /*var dropObject = GetComponentInChildren<PickableFunction>();
        if (dropObject)
            _pickableFunction.Drop();*/
    }

    public void OpenInventoryInterface()
    { 
        _inventoryUI.OpenInterface();
    }

    public void Escape()
    {
        _inventoryUI.CloseInterface();
    }

    /*public void SelectNextSlot()
    {
        _athInventory.NextSlot();
    }*/
}
