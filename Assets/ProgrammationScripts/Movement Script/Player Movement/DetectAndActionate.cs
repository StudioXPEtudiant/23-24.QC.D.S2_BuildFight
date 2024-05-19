using UnityEngine;

/// <summary>
/// Permet de gérer la détection des object avec le joueur
/// </summary>
public class DetectAndActionate : MonoBehaviour
{
    [SerializeField] private float distance;

    private bool _isTake;
    
    private OpenInventoryUI _inventoryUI;
    private SimpleConditionalAction _dialogue;
    private PickableFunction _pickableFunction;
    private NextLevelFunction _nextLevel;
    
    private RaycastHit _hit;

    private void Awake()
    {
        _inventoryUI = FindObjectOfType<OpenInventoryUI>();
        _pickableFunction = FindObjectOfType<PickableFunction>();
        _nextLevel = FindObjectOfType<NextLevelFunction>();
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
        
        _nextLevel = _hit.collider.GetComponent<NextLevelFunction>();
        if(_nextLevel)
            _nextLevel.NextLevel();
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
    }

    public void OpenInventoryInterface()
    { 
        _inventoryUI.OpenInterface();
    }

    public void Escape()
    {
        _inventoryUI.CloseInterface();
    }
}
