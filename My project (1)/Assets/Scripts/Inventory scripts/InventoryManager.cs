using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform SlotsPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private void Start()
    {
        for (int i = 0; i < SlotsPanel.childCount; i++)
        {
            if (SlotsPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(SlotsPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }
}
