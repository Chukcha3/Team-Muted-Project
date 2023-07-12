using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Default, Food, Weapon, Instrument }
public class ItemInfo : ScriptableObject
{
    public GameObject ItemDrop;
    public ItemType Type;
    public string itemName;
    public string itemDescription;
    public int maxAmount;
    public int Amount;

}
