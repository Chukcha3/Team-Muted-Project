using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CraftManager : MonoBehaviour
{



    [SerializeField] GameObject craftManagerOwner;
    private InventoryManager inventoryManager;
    [SerializeField] ItemPickUper itemPickUper;    
    void Start()
    {
        inventoryManager = craftManagerOwner.GetComponent<InventoryManager>();
    }

    public void ingredientAmountPlus(RecipeIngredient invItem, int numb)
    {
        invItem.amount += numb;
    }
    public bool isCanCraft(in List<RecipeIngredient> recipe)
    {
        List<RecipeIngredient> recipeCopy = new List<RecipeIngredient>(recipe.Count);
        recipe.ForEach((item) =>
        {
            recipeCopy.Add(new RecipeIngredient(item));
        });
        List<RecipeIngredient> invCopy = new List<RecipeIngredient>();

        bool isFirstItemAdded = false;
        foreach (InventorySlot slot in inventoryManager.slots)
        {
            if (slot.item != null)
            {
                foreach (RecipeIngredient invItem in invCopy)
                {
                    if (slot.item == invItem.itemInfo)
                    {
                        ingredientAmountPlus(invItem, slot.itemAmount);
                    }
                    else
                    {
                        RecipeIngredient helpVariable = new RecipeIngredient();
                        helpVariable.itemInfo = slot.item;
                        helpVariable.amount = slot.itemAmount;
                        invCopy.Add(helpVariable);
                        break;
                    }
                }
                if (!isFirstItemAdded)
                {
                    RecipeIngredient firstItem = new RecipeIngredient();
                    firstItem.itemInfo = slot.item;
                    firstItem.amount = slot.itemAmount;
                    invCopy.Add(firstItem);
                    isFirstItemAdded = true;
                }
            }
        }
        bool needRepeate = false;
        do
        {
            needRepeate = false;
            foreach (RecipeIngredient rItem in recipeCopy)
            {
                foreach (RecipeIngredient item in invCopy)
                {
                    if (item.itemInfo == rItem.itemInfo && item.amount >= rItem.amount)
                    {
                        invCopy.Remove(item);
                        recipeCopy.Remove(rItem);
                        needRepeate = true;
                        break;
                    }
                }
                if (needRepeate)
                {
                    break;
                }
            }
        } while (needRepeate);
        if (recipeCopy.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Craft(List<RecipeIngredient> recipe, ItemInfo craftItem)
    {
        
        foreach (RecipeIngredient rItem in recipe)
        {
            int recipeAmount = rItem.amount;
            foreach (InventorySlot slot in inventoryManager.slots)
            {
                bool isRItemEmpty = false;
                if (rItem.itemInfo == slot.item)
                {
                    for (int i = slot.itemAmount; i >= 0; i--)
                    {
                        recipeAmount--;
                        slot.DecreaseAmount(1);
                        if (recipeAmount <= 0) { isRItemEmpty = true; break; }
                    }
                    if(isRItemEmpty) { break; }

                }
            }
        }
        itemPickUper.AddItem(craftItem);
    }
    
}
