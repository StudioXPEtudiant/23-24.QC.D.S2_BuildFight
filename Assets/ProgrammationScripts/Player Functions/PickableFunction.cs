using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PickableFunction : MonoBehaviour
{
    /// <summary> Defini si l'object est une quete ou bien si il est ramassable </summary>
    [FoldoutGroup("Configuration"), SerializeField] private bool isPickable;
    [FoldoutGroup("Configuration"), SerializeField] private bool isQuest;
    
    [FoldoutGroup("Parameters", false)]
    [ShowIf("isPickable")]
    [SerializeField] private Vector3 pickUpPos;
    
    [FoldoutGroup("Parameters")]
    [ShowIf("isPickable")]
    [SerializeField] private Item item;
    
    [FoldoutGroup("Parameters")]
    [ShowIf("isQuest")]
    [SerializeField] private string questFlag;
    
    [FoldoutGroup("Parameters")]
    [ShowIf("isQuest")]
    [SerializeField] private int questValue;
    
    private InventorySystem _inventory;
    private AthInventorySystem _athInventory;
    private DetectAndActionate _detect;
    private SimpleGameFlagCollection _flag;
    private QuestUIController _quest;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _detect = FindObjectOfType<DetectAndActionate>();
        _inventory = FindObjectOfType<InventorySystem>();
        _athInventory = FindObjectOfType<AthInventorySystem>();
        _flag = FindObjectOfType<SimpleGameFlagCollection>();
        _quest = FindObjectOfType<QuestUIController>();
    }
    
    public void Pick()
    {
        if (isPickable)
        {
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
        }
        
        if (isQuest)
        {
            _flag.Triggers(questFlag);
            _quest.UpdateQuestUI(questValue);
            _quest.Hide();
            Destroy(gameObject);
        }
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