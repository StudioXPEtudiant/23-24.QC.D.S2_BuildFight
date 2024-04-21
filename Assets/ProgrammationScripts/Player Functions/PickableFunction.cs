using System;
using UnityEngine;

public class PickableFunction : MonoBehaviour
{
    /*[SerializeField] private Transform player;
    [SerializeField] private Transform playerCam;*/
    [SerializeField] private Vector3 pickUpPos;
    [SerializeField] private Item item;
    
    private InventorySystem _inventory;
    private AthInventorySystem _athInventory;
    private DetectAndActionate _detect;

    private Rigidbody _rb;
    
    /*private bool _hasPlayer;
    private bool _beCarried;
    private bool _touched;*/

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _detect = FindObjectOfType<DetectAndActionate>();
        _inventory = FindObjectOfType<InventorySystem>();
        _athInventory = FindObjectOfType<AthInventorySystem>();
    }
    
    public void Pick()
    {
        if(!_inventory.TrySetItemInEmptySlot(gameObject)) return;
        
        Transform transform1;
        (transform1 = transform).parent = _detect.GetComponent<Transform>();
        transform1.localPosition = pickUpPos;
        transform1.localScale = Vector3.one;
        
        _rb.isKinematic = true;
        _rb.useGravity = false;
        
        _inventory.AddItem(item);
        _athInventory.AddItemToAth(item);

        foreach (var col in GetComponents<Collider>())
        {
            col.enabled = false;
        }
        
        /*_rb.isKinematic = true;
        transform.parent = playerCam;*/
        //_beCarried = true;
        //Destroy(gameObject);
    }
    
    public void Drop()
    {
        /*if(_beCarried) return;

        if (!_touched) return;
        _rb.isKinematic = false;
        transform.parent = null;
        _beCarried = false;*/

        _inventory.PickItem(1);
        _athInventory.PickItemToAth(1);
        
        _rb.isKinematic = false;
        _rb.useGravity = true;
        
        transform.parent = null;

        foreach (var col in GetComponents<Collider>())
        {
            col.enabled = true;
        }
    }
}