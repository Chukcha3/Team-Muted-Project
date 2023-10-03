using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public int selectedSlotsAmount = 0;
    public int selectedSlotInt = 0;
    public GameObject inventory;
    public GameObject slotsPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private bool isOpen = false;
    [SerializeField] ItemInfo drillItem;
    [SerializeField] Transform fastPanel;
    [SerializeField] GameObject craftPanel;
    //[SerializeField] GameObject player;
    public void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlotInt != newValue)
        {
            fastPanel.GetChild(selectedSlotInt).GetComponent<InventorySlot>().DeselectSlot();
            fastPanel.GetChild(newValue).GetComponent<InventorySlot>().SelectSlot();
            selectedSlotInt = newValue;
        }
    }
    private void Awake()
    {
        fastPanel.transform.GetChild(0).GetComponent<InventorySlot>().SelectSlot();

    }
    private void Start()
    {
        slotsPanel.SetActive(false);
        craftPanel.SetActive(false);
        for (int i = 0; i < fastPanel.childCount; i++)
        {
            if (fastPanel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(fastPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        for (int i = 0; i < slotsPanel.transform.childCount; i++)
        {
            if (slotsPanel.transform.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                slots.Add(slotsPanel.transform.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.transform.parent == fastPanel)
            {
                slot.isOnFastPanel = true;
                selectedSlotsAmount++;
            }
    }
}
    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number <= selectedSlotsAmount)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            if(isOpen)
            {
                slotsPanel.SetActive(true);
                craftPanel.SetActive(true);
            }
            else
            {
                slotsPanel.SetActive(false);
                craftPanel.SetActive(false);    
            }
        }
    }
}
