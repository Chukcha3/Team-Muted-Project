using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory;
    public Transform SlotsPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private bool isOpen = false;
    private void Start()
    {
        inventory.SetActive(false);
        for (int i = 0; i < SlotsPanel.childCount; i++)
        {
            if (SlotsPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(SlotsPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }
    }
}
