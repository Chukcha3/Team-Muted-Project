using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{
    public Camera MyCamera;
    [SerializeField] float Damage, penetration, Range;
    private BuildingManager buildingManager;
    void Start()
    { 
        //MyCamera = GetComponent<Camera>();
        buildingManager = GetComponent<BuildingManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MyCamera)
        {
            if (buildingManager.GetCurrentSlot().item != null)
            {
                if (buildingManager.GetCurrentSlot().item.type == ItemType.Tool)
                {
                    Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
                    float Lenght = (new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - hit.point).magnitude;
                    if (hit.collider && Lenght < Range)
                    {
                        Debug.Log(Lenght);
                        if (hit.collider.GetComponent<TileStats>())
                        {
                            hit.collider.GetComponent<TileStats>().TakeDamage(Damage, penetration);
                        }
                    }
                }
            }
            
        }      
    }
}
