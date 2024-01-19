using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject craftManagerOwner;
    public ItemInfo craftItem;
    private CraftManager craftManager;
    [SerializeField] GameObject descriptionObject;
    private ItemDescription descriptionScript;
    private void Start()
    {
        descriptionScript = descriptionObject.GetComponent<ItemDescription>();
        craftManager = craftManagerOwner.GetComponent<CraftManager>();
    }
    public void ButtonClick()
    {
        if (craftManager.isCanCraft(craftItem.ingredients))
        {
            craftManager.Craft(craftItem.ingredients, craftItem);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionScript.isMouseOnSlot = true;
        descriptionScript.name.text = craftItem.name;
        string description = "";
        foreach (RecipeIngredient ingredient in craftItem.ingredients)
        {
            description += ingredient.amount.ToString() + " ";
            description += ingredient.itemInfo.name;
            description += "\n";
        }
        descriptionScript.description.text = description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionScript.isMouseOnSlot = false;
    }
}
