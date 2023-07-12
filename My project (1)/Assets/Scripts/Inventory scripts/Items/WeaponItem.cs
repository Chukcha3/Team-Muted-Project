using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item", menuName = "Inventory/Items/new Weapon item")]
public class WeaponItem : ItemInfo
{
    //public ItemType itemType = ItemType.Weapon;
    public float damage;
    public float attackSpeed;

}
