using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool isEmpty = true;
    public ItemInfo item;
    public int itemAmount;
    public TMP_Text itemAmountText;
    public GameObject icon;

    private void Start()
    {
        icon = transform.GetChild(0).gameObject;
        itemAmountText = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    public void SetIcon(Sprite icon)
    {
        this.icon.GetComponent<Image>().color = new Color(1,1,1,1);
        this.icon.GetComponent<Image>().sprite = icon;
    }
}
