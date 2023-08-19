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
    public Image icon;

    private void Start()
    {
        icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        itemAmountText = transform.GetChild(1).GetComponent<TMP_Text>();
    }
    public void SetIcon(Sprite icon)
    {
        this.icon.GetComponent<Image>().color = new Color(1,1,1,1);
        this.icon.GetComponent<Image>().sprite = icon;
    }
    public void RemoveItem()
    {
        item = null;
        isEmpty = true;
        itemAmountText.text = "";
        icon.sprite = null;
        icon.color = new Color(1,1,1,0);
        itemAmount = 0;
    }
    public void DecreaseAmount(int amount)
    {
        itemAmount -= amount;
        if (itemAmount > 0)
        {
            itemAmountText.text = itemAmount.ToString();
        }
        else
        {
            RemoveItem();

        }

    }
}