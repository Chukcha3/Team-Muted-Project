using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : BaseWeapon
{
    [SerializeField] GameObject player;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayer;
    override public void Attack()
    {
        Debug.Log("melee weapon attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(player.transform.GetChild(3).position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<HealthPoints>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (player.transform.GetChild(3) == null)
            return;
        Gizmos.DrawWireSphere(player.transform.GetChild(3).position, attackRange);
    }
}
