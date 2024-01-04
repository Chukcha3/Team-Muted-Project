using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public float seeDistance;
    public Transform target;
    public Transform botTransform;
    public float attackRange;
    public Rigidbody2D rigidbody;
    public float moveSpeed;
    public float distanceToObstacleToJump;
    public float jumpForce;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentState = new IdleState(this);   
    }
    void Update()
    {
        RunStateMachine();
    }
    private void RunStateMachine()
    {
        currentState.PlayState(this);
    }
    public void SwitchState(BaseState newState)
    {
        currentState = newState;
    }
}
