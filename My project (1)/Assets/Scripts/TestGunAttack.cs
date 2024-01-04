using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGunAttack : BaseWeapon
{
    public GameObject bullet;
    public float nextShotTime = 0;
    [SerializeField] public float bulletSpeed;
    public override void Attack(Vector2 attackPoint)
    {
        if (Time.time >= nextShotTime)
        {
            GameObject thisWeapon = GameObject.FindGameObjectWithTag("weapon");
            Vector2 diraction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - thisWeapon.transform.GetChild(0).position).normalized;
            GameObject newBullet = Instantiate(bullet, thisWeapon.transform.GetChild(0).position, thisWeapon.transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddForce(diraction * bulletSpeed, ForceMode2D.Impulse);
            Destroy(newBullet, 4);
            nextShotTime = Time.time + attackSpeed;
        }
    }
    private void Start()
    {
        nextShotTime = 0;
    }

}
