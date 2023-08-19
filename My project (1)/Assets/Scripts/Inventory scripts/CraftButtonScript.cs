using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CraftButtonScript : MonoBehaviour
{
    [SerializeField] GameObject craftManagerOwner;
    public ItemInfo craftItem;
    private CraftManager craftManager;
    private void Start()
    {
        craftManager = craftManagerOwner.GetComponent<CraftManager>();
    }
    public void ButtonClick()
    {
        if (craftManager.isCanCraft(craftItem.ingredients))
        {
            craftManager.Craft(craftItem.ingredients, craftItem);
        }
    }
}
