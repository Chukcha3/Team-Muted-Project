using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public bool isBulletEnemy;
    public GameObject weaponThatShotMe;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isBulletEnemy)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<HealthPoints>().TakeDamage(weaponThatShotMe.GetComponent<BaseWeapon>().damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<HealthPoints>().TakeDamage(weaponThatShotMe.GetComponent<BaseWeapon>().damage);
            }
            Destroy(gameObject);
        }
    }
}
