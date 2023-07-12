using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/new Food item")]
public class FoodItem : ItemInfo
{
    //public ItemType itemType = ItemType.Food;
    public float healAmount;
    public float satietyAmount;
}
