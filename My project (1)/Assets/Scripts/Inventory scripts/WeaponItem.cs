using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon item", menuName = "Inventory/Items/new Weapon item")]

public class WeaponItem : ItemInfo
{
    public float damage;
    public float attackSpeed;
    public float attackRange;
}
