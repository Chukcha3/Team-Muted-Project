using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    [SerializeField]PlayerMove3 Script;
    [SerializeField] float Check = 0;
    [SerializeField] Animator animator;
    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Check += 1;
            Script.Jump = 0;
            animator.SetBool("IsJump", false);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (Check <= 1)
            {
                Script.Jump = 1;
            }
            Check -= 1;
            animator.SetBool("IsJump", true);
        }
    }
}
