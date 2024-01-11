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
    private BuildingManager buildingManager;
    private CameraScript cameraScript;
    [SerializeField] Transform fastPanel;
    [SerializeField] GameObject craftPanel;
    [SerializeField] GameObject player;
    [SerializeField] AttackScript attackScript;
    public void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlotInt != newValue)
        {
            fastPanel.GetChild(selectedSlotInt).GetComponent<InventorySlot>().DeselectSlot();
            fastPanel.GetChild(newValue).GetComponent<InventorySlot>().SelectSlot();
            selectedSlotInt = newValue;
            if (player.transform.GetChild(3).childCount >= 1)
            {
                Destroy(player.transform.GetChild(3).GetChild(0).gameObject);
                attackScript.baseWeapon = null;
            }
            if (fastPanel.GetChild(newValue).GetComponent<InventorySlot>().item != null)
            {

                if (fastPanel.GetChild(newValue).GetComponent<InventorySlot>().item is WeaponItem weaponItem)
                {
                    //WeaponItem weaponItem = (WeaponItem)fastPanel.GetChild(newValue).GetComponent<InventorySlot>().item;
                    attackScript.baseWeapon = weaponItem.weaponPrefab.GetComponent<BaseWeapon>();
                    Instantiate(weaponItem.weaponPrefab, player.transform.GetChild(3).position, player.transform.GetChild(3).rotation, player.transform.GetChild(3));
                }
                else if (fastPanel.GetChild(newValue).GetComponent<InventorySlot>().item is ToolItem ToolItem)
                {
                    Instantiate(ToolItem.toolPrefab, player.transform.GetChild(3).position, player.transform.GetChild(3).rotation, player.transform.GetChild(3));
                }

            }
        }
    }
    private void Awake()
    {
        attackScript = player.GetComponent<AttackScript>();
        fastPanel.transform.GetChild(0).GetComponent<InventorySlot>().SelectSlot();
        buildingManager = player.GetComponent<BuildingManager>();
        cameraScript = Camera.main.GetComponent<CameraScript>();
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
        if (Input.GetMouseButtonDown(0))
        {
            if (buildingManager.GetCurrentSlot().item != null)
            {
                if (buildingManager.GetCurrentSlot().item.type == ItemType.Food)
                {
                    BuildRocket(buildingManager.GetCurrentSlot());
                }
            }
        }
    }
    private void BuildRocket(InventorySlot slot)
    {
        GameObject rocket = Instantiate(slot.item.rocket, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        slot.DecreaseAmount(1);
        cameraScript.target = rocket;
    }
}
