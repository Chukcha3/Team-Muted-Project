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
    private AttackScript attackScript;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attackScript = player.GetComponent<AttackScript>();
    }
    public void OnBeginDrag (PointerEventData eventData)
    {
        mainParent = transform.parent;
        slotBeforeDragging = transform.parent.GetComponent<InventorySlot>();
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        if (player.transform.GetChild(3).childCount >= 1)
        {
            Destroy(player.transform.GetChild(3).GetChild(0).gameObject);
            attackScript.baseWeapon = null;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(mainParent);
        image.raycastTarget = true;
        InventorySlot slotAfterDragging = mainParent.GetComponent<InventorySlot>();
        if (slotAfterDragging.isCurrentISlot == true)
        {
            if (slotAfterDragging.item != null)
            {
                if (slotAfterDragging.item.type == ItemType.Weapon)
                {
                    if (slotAfterDragging.item is WeaponItem weaponItem)
                    {
                        attackScript.baseWeapon = weaponItem.weaponPrefab.GetComponent<BaseWeapon>();
                        Instantiate(weaponItem.weaponPrefab, player.transform.GetChild(3).position, player.transform.GetChild(3).rotation, player.transform.GetChild(3));

                    }
                }
            }
        }
    }
}
