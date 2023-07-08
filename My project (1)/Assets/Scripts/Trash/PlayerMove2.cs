using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    [SerializeField] float Speed = 1.0f, JumpForce = 10f, Gravity = 9.8f;
    [SerializeField] IsStay isStay;
    void Start()
    {
        
    }

    void Update()
    {
        bool Space = Input.GetKeyDown(KeyCode.Space);
        if (Space)
        {
            Debug.Log("Space");
        }
        bool a = isStay.Stay;
        float Ymovement;
        if (a && Space)
        {
            Ymovement = JumpForce;
            Debug.Log("Jump");
        }
        if (a)
        {
            Ymovement = 0;
            Debug.Log("Stay");
        }
        else
        {
            Ymovement = -Gravity;
            Debug.Log("Fall");
        }
        transform.position += new Vector3(Input.GetAxis("Horizontal") * Speed, Ymovement);
    }
}
