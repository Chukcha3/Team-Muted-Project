using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3 : MonoBehaviour
{
    [SerializeField] public GameObject muzzlePoint;
    [SerializeField] float Speed = 1f, JumpForce = 5f, HorizontalMove;
    [SerializeField] int MaxJumpsCount = 1;
    [SerializeField] Animator animator;
    bool Flip;
    public int Jump = 0;
    Rigidbody2D MyRigidbody2D;
    void Start()
    {
        MyRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MyRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, MyRigidbody2D.velocity.y);
        HorizontalMove = Input.GetAxisRaw("Horizontal") * Speed;
        if (HorizontalMove > 0 && Flip)
        {
            LookDirection();
        }
        else if (HorizontalMove < 0 && !Flip)
        {
            LookDirection();
        }
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));   
        if (Input.GetKeyDown(KeyCode.Space) && MaxJumpsCount > Jump)
        {
            Jump++;
            //MyRigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed, JumpForce);
            MyRigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }
    private void LookDirection()
    {
        Flip = !Flip;
        Vector3 SC = transform.localScale;
        SC.x *= -1;
        transform.localScale = SC;
    }
}
