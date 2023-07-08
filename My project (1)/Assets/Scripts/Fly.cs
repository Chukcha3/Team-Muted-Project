using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [SerializeField] float Speed = 1f;
    Rigidbody2D MyRigidbody2D;
    void Start()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MyRigidbody2D.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Speed);
    }
}
