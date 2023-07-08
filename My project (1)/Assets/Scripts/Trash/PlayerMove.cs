using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float Speed = 1.0f, JumpForce = 10f, Gravity = 9.8f;
    float Ymovement, MaxRayDistance = 1.0f;
    [SerializeField] Transform ReyPoint;
    void Start()
    {
    }
    void Update()
    {
        //Ignore Raycast
        bool Space = Input.GetKeyDown(KeyCode.Space);
        List<RaycastHit2D> hitInfo = new List<RaycastHit2D>();
        ContactFilter2D Filter = new ContactFilter2D();
        Filter.layerMask = ~LayerMask.GetMask("Ground");
        int Hits = Physics2D.Raycast(new Vector2(ReyPoint.position.x, ReyPoint.position.y), new Vector2(ReyPoint.position.x, ReyPoint.position.y - MaxRayDistance), Filter, hitInfo, MaxRayDistance);

        if (Hits > 0)
        {
            Ymovement = 0;
            if (Space)
            {
                Ymovement = JumpForce;
                Debug.Log("Jump");
            }
        }
        else
        {   
            Ymovement = -Gravity;
            Debug.Log("Fly");
        }
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed, Ymovement);
        Debug.DrawLine(new Vector2(ReyPoint.position.x, ReyPoint.position.y), new Vector2(ReyPoint.position.x, ReyPoint.position.y - MaxRayDistance), Color.yellow, MaxRayDistance);
        Debug.Log(Hits);
    }
    /*void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector2(ReyPoint.position.x, ReyPoint.position.y), 0.2f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector2(ReyPoint.position.x, ReyPoint.position.y - MaxRayDistance), 0.2f);
    }*/
}
