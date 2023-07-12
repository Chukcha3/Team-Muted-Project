using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUper : MonoBehaviour
{
    [SerializeField] Camera inventoryManagerOwner; // Об'єкт на якому знаходиться InventoryManager (камера)
    private InventoryManager inventoryManager;
    private InventorySlot inventorySlot;
    private void Start()
    {
        inventoryManager = inventoryManagerOwner.GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DropedItem>() != null)
        {
            AddItem(collision.GetComponent<DropedItem>().itemInfo, collision.GetComponent<DropedItem>().itemInfo.amount, collision.GetComponent<DropedItem>().itemInfo.maxAmount);
            Destroy(collision.gameObject);
        }
    }
    public void AddItem(ItemInfo item, int amount, int maxAmount)
    {
        for (int i = 0; i < inventoryManager.slots.Count; i++)
        {
            if (inventoryManager.slots[i].GetComponent<InventorySlot>().item == item)
            {
                if (inventoryManager.slots[i].itemAmount < maxAmount)
                {
                    inventoryManager.slots[i].GetComponent<InventorySlot>().itemAmount += amount;
                    return;
                }
            }
        }
        for (int i = 0; i < inventoryManager.slots.Count; i++)
        {
            if (inventoryManager.slots[i].GetComponent<InventorySlot>().isEmpty)
            {
                inventoryManager.slots[i].item = item;
                inventoryManager.slots[i].itemAmount = amount;
                inventoryManager.slots[i].isEmpty = false;
                return;
            }
        }
    }
}
