using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    private GameObject player;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    private PlayerMove3 playerScript;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMove3>();
        if (playerScript == null)
        {
            Debug.Log("error");
        }
    }
    override public void Attack()
    {
        Debug.Log("melee weapon attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerScript.muzzlePoint.transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<HealthPoints>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (player.transform.GetChild(3) == null)
            return;
        Gizmos.DrawWireSphere(playerScript.muzzlePoint.transform.position, attackRange);
    }
}
