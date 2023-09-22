using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform mainParent;
    public Image image;
    public InventorySlot slotBeforeDragging;
    public void OnBeginDrag (PointerEventData eventData)
    {
        Debug.Log("efe");

        mainParent = transform.parent;
        slotBeforeDragging = transform.parent.GetComponent<InventorySlot>();
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(mainParent);
        image.raycastTarget = true;
    }
}
