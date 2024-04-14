using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Slot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    private int _index;
    private Vector3 _initialImageLocalPosition;

    [SerializeField] private TextMeshProUGUI itemCounText;
    [SerializeField] private Image itemImage;

    private InventoryDisplay _inventoryDisplay;
    private Button _button;
    private IBeginDragHandler _beginDragHandlerImplementation;

    public void Initialized(InventoryDisplay inventoryDisplay, int index)
    {
        _button = GetComponent<Button>();

        _button.onClick.AddListener(OnClick);
        _index = index;
        _inventoryDisplay = inventoryDisplay;
    }

    public void UpdateDisplay(Resources item)
    {
        if (item.Empty) return;
        itemCounText.text = item.Count.ToString();
        itemImage.sprite = item.Data.icon;
        itemImage.color = Color.white;
    }

    private void OnClick()
    {
        _inventoryDisplay.ClickSlot(_index);
    }

    #region Drag and Drop

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        _inventoryDisplay.DragSlot(_index);

        _initialImageLocalPosition = itemImage.transform.localPosition;
        itemImage.transform.SetParent(_inventoryDisplay.transform);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        itemImage.transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Transform transform1;
        (transform1 = itemImage.transform).SetParent(transform);
        transform1.localPosition = _initialImageLocalPosition;
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        _inventoryDisplay.DropOnSlot(_index);
    }

    #endregion
}