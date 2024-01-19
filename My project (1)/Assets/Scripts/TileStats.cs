using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStats : MonoBehaviour
{
    [SerializeField] float Armor, Health, MaxHealth, RegenerationTime;
    [SerializeField] GameObject Drop;
    [SerializeField] int maxDropAmount;
    [SerializeField] int minDropAmount;
    [SerializeField] float dropForce;
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
            int dropAmount = Random.Range(minDropAmount, maxDropAmount + 1);
            for (int i = 0; i < dropAmount; i++)
            {

                GameObject drop = Instantiate(Drop, gameObject.transform.position, Quaternion.identity);
                Vector2 dropDirection = new Vector2 (0.0f, 1.0f);
                dropDirection.x = Random.Range(-1.0f, 2.0f);
                drop.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
            }
        }
    }
}
