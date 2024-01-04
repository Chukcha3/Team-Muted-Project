using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health2 : MonoBehaviour
{
    [SerializeField] public enum healthType {Default, Fire, Water, Plant }
    [SerializeField] public healthType element;
    [SerializeField] public float maxHp, hp, hpRegen, multiply;
    public void TakeDamage(float damage, healthType type)
    {
        hp -= damage * multiply;
    }
    private void Update()
    {
        if (hp < maxHp)
        {
            hp += hpRegen;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void Start()
    {
        
    }
}
