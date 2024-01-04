using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickUper : MonoBehaviour
{
    [SerializeField] Camera inventoryManagerOwner; // ќб'Їкт на €кому знаходитьс€ InventoryManager (камера)
    private InventoryManager inventoryManager;
    private AttackScript attackScript;
    [SerializeField] private GameObject player;
    private void Start()
    {
        attackScript = player.GetComponent<AttackScript>();
        inventoryManager = inventoryManagerOwner.GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DropedItem>() != null)
        {
            AddItem(collision.GetComponent<DropedItem>().itemInfo);
            Destroy(collision.gameObject);
            
        }
    }
    public void AddItem(ItemInfo item)
    {
        // якщо вже Ї цей айтем
        for (int i = 0; i < inventoryManager.slots.Count; i++)
        {
            if (inventoryManager.slots[i].GetComponent<InventorySlot>().item == item)
            {
                if (inventoryManager.slots[i].itemAmount < item.maxAmount)
                {
                    inventoryManager.slots[i].GetComponent<InventorySlot>().itemAmount += item.amount;
                    inventoryManager.slots[i].itemAmountText.text = inventoryManager.slots[i].GetComponent<InventorySlot>().itemAmount.ToString();
                    return;
                }
            }
        }
        // якщо нема
        for (int i = 0; i < inventoryManager.slots.Count; i++)
        {
            if (inventoryManager.slots[i].GetComponent<InventorySlot>().isEmpty)
            {
                inventoryManager.slots[i].item = item;
                inventoryManager.slots[i].itemAmount = item.amount;
                inventoryManager.slots[i].isEmpty = false;
                inventoryManager.slots[i].SetIcon(item.icon);
                inventoryManager.slots[i].itemAmountText.text = item.amount.ToString();
                if (inventoryManager.slots[i].isCurrentISlot)
                {
                    if (inventoryManager.slots[i].item is WeaponItem weaponItem)
                    {
                        attackScript.baseWeapon = weaponItem.weaponPrefab.GetComponent<BaseWeapon>();
                        Instantiate(weaponItem.weaponPrefab, player.transform.GetChild(3).position, player.transform.GetChild(3).rotation, player.transform.GetChild(3));
                    }
                    else if (inventoryManager.slots[i].item is ToolItem ToolItem)
                    {
                        Instantiate(ToolItem.toolPrefab, player.transform.GetChild(3).position, player.transform.GetChild(3).rotation, player.transform.GetChild(3));
                    }
                }
                return;
            }
        }
    }
    
    
}
