using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeItemIngredient", menuName = "Inventory/Items/new Recipe item ingredient")]
public class RecipeIngredient : ScriptableObject
{
    public ItemInfo itemInfo;
    public int amount;
    public void IngredientAmountMinus(int numb)
    {
        amount -= numb;
    }
    public RecipeIngredient(RecipeIngredient item) 
    {
        amount = item.amount;
        itemInfo = item.itemInfo;
    }

    public RecipeIngredient() { }
}
