using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Digging : MonoBehaviour
{
    [SerializeField] public Camera MyCamera;
    [SerializeField] float Damage, penetration, Range, Cooldown = 1.0f;
    [SerializeField] GameObject Weapon, Triangle;
    private BuildingManager buildingManager;
    float tim, offset = 0.5f;
    //SpriteRenderer TSpriteRenderer;
    void Start()
    {
        //MyCamera = GetComponent<Camera>();
        buildingManager = GetComponent<BuildingManager>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (MyCamera && buildingManager.GetCurrentSlot().item != null && buildingManager.GetCurrentSlot().item.type == ItemType.Tool)
            {
                if (Time.time >= tim)
                {
                    Dig();
                    tim = Time.time + Cooldown;
                }
            }
            
        }
        else
        {
            Triangle.SetActive(false);
        }
    }
    private void Dig()
    {
        Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
        float Lenght = (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - hit.point).magnitude;
        if (hit.collider && Lenght < Range)
        {
            //Debug.Log(Lenght);
            TileStats Stat = hit.collider.GetComponent<TileStats>();
            if (Stat)
            {
                Triangle.SetActive(true);
                //DrawTriangle(Stat.gameObject.transform.position);
                Stat.TakeDamage(Damage, penetration);
            }
        }
        else
        {
            Triangle.SetActive(false);
        }
    }
    private void DrawTriangle(Vector3 Position)
    {
        Weapon.transform.LookAt(Position);
        Weapon.transform.rotation = Quaternion.LookRotation(Vector3.forward, Position - Weapon.transform.position);
        if (Weapon.transform.rotation.z > 0)
        {
            Triangle.transform.localScale = new Vector2(-1.0f, 0f);
        }
        else
        {
            Triangle.transform.localScale = new Vector2(1.0f, 0f);
        }
        float Distance = (Position - Weapon.transform.position).magnitude - offset;
        Triangle.transform.localScale = new Vector3(Distance, 1, 1);
        Triangle.transform.localPosition = new Vector3(Distance * 0.5f, 0, 0);
    }
}


