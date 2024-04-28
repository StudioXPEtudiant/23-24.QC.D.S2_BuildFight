using UnityEngine;

public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float distance;
    //[SerializeField] private LayerMask layers;

    private bool _isTake;
    private OpenInventoryUI _inventoryUI;
    //private AthInventorySystem _athInventory;
    
    private SimpleConditionalAction _dialogue;
    
    private PickableFunction _pickableFunction;

    private RaycastHit _hit;

    private void Awake()
    {
        _inventoryUI = FindObjectOfType<OpenInventoryUI>();
        //_athInventory = FindObjectOfType<AthInventorySystem>();
        _pickableFunction = FindObjectOfType<PickableFunction>();
    }
    //Quand je joueur clique sur le bouton gauche de la souris
    public void ActionateObjectFirstAction()
    {
        if(Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out _hit, distance)) return;

        _dialogue = _hit.collider.GetComponent<SimpleConditionalAction>();

        if (_dialogue) 
            _dialogue.Execute();
    }

    public void InteractObject()
    {
        if (Camera.main == null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(!Physics.Raycast(ray, out _hit, 5)) return;

        _pickableFunction = _hit.collider.GetComponent<PickableFunction>(); 
        
        if (!_pickableFunction) return;
        _isTake = true;
        _pickableFunction.Pick();

        /*var dropObject = GetComponentInChildren<PickableFunction>();
        if (dropObject)
            _pickableFunction.Drop();*/
    }

    /*public void DropObject()
    {
        if(_isTake) return;
        _pickableFunction.Drop();
        _isTake = false;
    }*/

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
