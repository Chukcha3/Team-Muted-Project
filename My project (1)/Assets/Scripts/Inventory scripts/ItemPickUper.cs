using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUper : MonoBehaviour
{
    [SerializeField] Camera InventoryManagerObject;
    private InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = InventoryManagerObject.GetComponent<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DropedItem>() != null)
        {
            AddItem(collision.GetComponent<DropedItem>().appropriateItem, collision.GetComponent<DropedItem>().appropriateItem.Amount);
            Destroy(collision.gameObject);
        }
    }
    public void AddItem(ItemInfo item, int amount)
    {
        for (int i = 0; i < inventoryManager.slots.Count; i++)
        {
            if (inventoryManager.slots[i].item == item)
            {
                if (inventoryManager.slots[i].itemAmount < item.maxAmount)
                {
                    inventoryManager.slots[i].itemAmount += amount;
                    return;
                }                
            }
        }
        for (int i = 0; i < inventoryManager.slots.Count; i++)
        {
            if (inventoryManager.slots[i].isEmpty)
            {
                inventoryManager.slots[i].item = item;
                inventoryManager.slots[i].itemAmount = amount;
                inventoryManager.slots[i].isEmpty = false;
                return;
            }
        }
    }
}
