using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField] public enum healthType {Default, fire, water, plant}
    [SerializeField] public healthType element;
    [SerializeField] healthType myhealthType = healthType.Default;
    [SerializeField] public float maxHp;
    [SerializeField] public float hp;
    [SerializeField] public float hpRegen, multiple;
    public void TakeDamage(float damage, healthType damageType)
    {
        if ((myhealthType == healthType.water && damageType == healthType.plant) || (myhealthType == healthType.plant && damageType == healthType.fire) || (myhealthType == healthType.fire && damageType == healthType.water))
        {
            multiple = 2;
        }
        else if ((myhealthType == healthType.water && damageType == healthType.fire) || (myhealthType == healthType.plant && damageType == healthType.water) || (myhealthType == healthType.fire && damageType == healthType.plant))
        {
            multiple = 0.5f;
           

        }
        else
        {
            multiple = 1;
        }
        hp -= damage * multiple;
    }
    public void ChangeHP()
    {
        hp += hpRegen;
        hp = Mathf.Clamp(hp, 0, maxHp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (hp < maxHp)
        {
            ChangeHP();
        }
    }
    
}
