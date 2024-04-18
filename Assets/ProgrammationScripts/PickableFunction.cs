using System;
using UnityEngine;

public class PickableFunction : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerCam;
    [SerializeField] private Item item;
    
    private InventorySystem _inventory;
    private AthInventorySystem _athInventory;

    private Rigidbody _rb;
    
    private bool _hasPlayer;
    private bool _beCarried;
    private bool _touched;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _inventory = FindObjectOfType<InventorySystem>();
        _athInventory = FindObjectOfType<AthInventorySystem>();
    }
    
    public void Pick()
    {
        var distance = Vector3.Distance(gameObject.transform.position, player.position);

        _hasPlayer = distance <= 5;

        if (!_hasPlayer) return;
        
        /*_rb.isKinematic = true;
        transform.parent = playerCam;*/
        _beCarried = true;
        _inventory.AddItem(item);
        _athInventory.AddItemToAth(item);
        Destroy(gameObject);
    }
    
    public void Drop()
    {
        if(_beCarried) return;

        if (!_touched) return;
        _rb.isKinematic = false;
        transform.parent = null;
        _beCarried = false;
    }
}