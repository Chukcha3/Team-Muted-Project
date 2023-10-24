using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public float damage;
    virtual public void Attack()
    {
        Debug.Log("base weapon attack");
    }
}
