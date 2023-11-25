using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public enum healthType {Default, fire, water, plant}
    [SerializeField] public healthType element;
    [SerializeField] public float maxHp;
    [SerializeField] public float hp;
    [SerializeField] public float hpRegen;
    public void TakeDamage(float damage)
    {
        
        hp -= damage;
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
}
