using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 1.0f, JumpForce = 5f;
    Rigidbody2D MyRigidbody;
    Vector3 MoveDirection;
    float Jump, MaxRayDistance = 5.0f;
    [SerializeField] Transform ReyPoint;
    LayerMask NoReycastMask;
    void Start()
    {
        MyRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        bool Space = Input.GetKeyDown(KeyCode.Space);
        if (Space)
        {
            Debug.Log("Space");
        }
        if (Physics2D.Raycast(new Vector2(ReyPoint.position.x, ReyPoint.position.y), new Vector2(ReyPoint.position.x, ReyPoint.position.y - MaxRayDistance), MaxRayDistance) == true && Space)
        {
            Jump = JumpForce;
            Debug.Log("I stay");
        }
        else
        {
            Jump = 0.0f;
            Debug.Log("I dont`t stay");
        }
        MoveDirection = new Vector3(Input.GetAxis("Horizontal") * Speed, Jump);
        MyRigidbody.AddForce(MoveDirection, ForceMode2D.Force);
        Debug.DrawLine(new Vector2(-1.0f, 1.0f), new Vector2(5.0f, 2.0f), Color.cyan);
        Debug.DrawLine(ReyPoint.transform.position, ReyPoint.transform.position - new Vector3(0.0f, MaxRayDistance), Color.yellow, MaxRayDistance);
        //Debug.Log(ReyPoint.transform.position + " " + (ReyPoint.transform.position - new Vector3(0.0f, MaxRayDistance)));
        //Physics2D.Raycast(ReyPoint.transform.position, ReyPoint.transform.position - new Vector3(0.0f, MaxRayDistance), MaxRayDistance, NoReycastMask);
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector2(ReyPoint.position.x, ReyPoint.position.y), 1);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector2(ReyPoint.position.x, ReyPoint.position.y - MaxRayDistance), 1);
    }
}
