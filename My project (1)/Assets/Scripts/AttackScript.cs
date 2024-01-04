using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public BaseWeapon baseWeapon;
    private BuildingManager buildingManager;
    [SerializeField] Transform attackPoint;
    private void Start()
    {
        buildingManager = GetComponent<BuildingManager>();
    }
    public void SetBaseWeapon(BaseWeapon newBaseWeapon)
    {
        baseWeapon = newBaseWeapon;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (buildingManager.GetCurrentSlot().item != null)
            {
                if (buildingManager.GetCurrentSlot().item.type == ItemType.Weapon)
                {
                    if (baseWeapon != null)
                    {
                        baseWeapon.Attack(transform.position);
                    }
                }
            }
        }
    }
}
