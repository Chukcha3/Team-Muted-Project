using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStats : MonoBehaviour
{
    [SerializeField] float Armor, Health, MaxHealth, RegenerationTime;
    [SerializeField] GameObject Drop;
    SpriteRenderer MySpriteRenderer;
    void Start()
    {
        
        MySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage, float penetration)
    {
        if (Armor <= penetration)
        {
            Health = Health - damage;
            MySpriteRenderer.color *= new Color(1,1,1) * (Health / MaxHealth);
        }
        if (Health <= 0)
        {
            Destroy(gameObject);

            Instantiate(Drop, gameObject.transform.position, Quaternion.identity);
        }
    }
}
