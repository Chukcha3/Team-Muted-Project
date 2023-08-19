using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum ItemType {Default, Food, Weapon}
public class ItemInfo : ScriptableObject
{
    
    public bool isCraftableItem;
    public List<RecipeIngredient> ingredients;
    public int craftAmount;
    public ItemType type;
    public string itemName;
    public string itemDescription;
    public int amount;
    public int maxAmount;
    public GameObject appropriateItem;
    public Sprite icon;
}
