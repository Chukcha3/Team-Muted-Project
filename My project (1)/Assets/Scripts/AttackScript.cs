using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public BaseWeapon baseWeapon;
    private BuildingManager buildingManager;
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
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (baseWeapon != null)
                        baseWeapon.Attack();
                    }
                }
            }
        }
    }
}
