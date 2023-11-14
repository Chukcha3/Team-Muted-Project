using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    enum damageType {defaultDamage, fireGamage, waterDamage, plantDamage }
    public float damage;
    virtual public void Attack()
    {
        Debug.Log("base weapon attack");
    }
}
