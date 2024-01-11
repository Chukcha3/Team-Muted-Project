using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public enum damageType {defaultDamage, fireGamage, waterDamage, plantDamage }
    public float damage;
    public float attackSpeed;
    public bool canAttack;
    virtual public void Attack(Vector2 attackPoint)
    {
        Debug.Log("base weapon attack");
    }
}
