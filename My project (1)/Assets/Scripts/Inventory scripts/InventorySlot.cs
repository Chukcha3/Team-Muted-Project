using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image imeg;
    public bool isEmpty = true;
    public ItemInfo item;
    public int itemAmount;
    public TMP_Text itemAmountText;
    public Image icon;
    [SerializeField] Color selectedColor;
    [SerializeField] Color deselectedColor;
    public bool isOnFastPanel = false;
    public bool isCurrentISlot = false;
    public bool drillSlot = false;
    public Transform player;
    [SerializeField] private GameObject descriptionObject;
    private ItemDescription description;
    public void SelectSlot()
    {
        imeg.color = selectedColor;
        isCurrentISlot = true;
    }
    public void DeselectSlot()
    {
        imeg.color = deselectedColor;
        isCurrentISlot = false;
    }
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        Drag drag = dropped.GetComponent<Drag>();
        if (drag.slotBeforeDragging != this)
        {
            transform.GetChild(0).SetParent(drag.slotBeforeDragging.transform);
            ExchangeSlots(ref drag.slotBeforeDragging);
        }
        drag.mainParent = transform;
    }
    
    private void Start()
    {
        icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        itemAmountText = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        description = descriptionObject.GetComponent<ItemDescription>();
    }
    public void SetIcon(Sprite icon)
    {
        this.icon.GetComponent<Image>().color = new Color(1,1,1,1);
        this.icon.GetComponent<Image>().sprite = icon;
    }
    public void RemoveItem()
    {
        item = null;
        isEmpty = true;
        itemAmountText.text = "";
        icon.sprite = null;
        icon.color = new Color(1,1,1,0);
        itemAmount = 0;
    }
    public void DecreaseAmount(int amount)
    {
        itemAmount -= amount;
        if (itemAmount > 0)
        {
            itemAmountText.text = itemAmount.ToString();
        }
        else
        {
            RemoveItem();
        }
    }
    public void ExchangeSlots(ref InventorySlot slot)
    {
        InventorySlot slotCopy = new InventorySlot();
        slotCopy.SlotInfoCopy(this);
        this.SlotInfoCopy(slot);
        slot.SlotInfoCopy(slotCopy);
    }
    public void SlotInfoCopy(InventorySlot slot1)
    {
        this.icon = slot1.icon;
        this.isEmpty = slot1.isEmpty;
        this.item = slot1.item;
        this.itemAmount = slot1.itemAmount;
        this.itemAmountText = slot1.itemAmountText;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            description.isMouseOnSlot = true;
            description.name.text = item.name;
            description.description.text = item.itemDescription;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.isMouseOnSlot = false;
    }
}
