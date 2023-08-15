using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digging : MonoBehaviour
{
    public Camera MyCamera;
    [SerializeField] float Damage, penetration;
    void Start()
    { 
        //MyCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && MyCamera)
        {
            Ray ray = MyCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.GetComponent<TileStats>())
                {
                    hit.collider.GetComponent<TileStats>().TakeDamage(Damage, penetration);
                }
            }
            
        }      
    }
}
