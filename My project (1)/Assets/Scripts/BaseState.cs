using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public BaseState(StateManager newStateManager)
    {
        currentStateManager = newStateManager;
    }
        

    protected StateManager currentStateManager;
    public abstract void PlayState(StateManager stateManager);
    public bool DoISeePlayer(StateManager stateManager)
    {
        LayerMask layer = ~LayerMask.GetMask("Enemies");
        RaycastHit2D hit = Physics2D.Raycast(stateManager.botTransform.position, (stateManager.target.position - stateManager.botTransform.position).normalized, stateManager.seeDistance, layer);
        Debug.DrawRay(stateManager.botTransform.position, stateManager.target.position - stateManager.botTransform.position);
        if (hit.collider != null && hit.collider.CompareTag("Player")){
            return true;
        }
        else{
            return false;
        }
    }
    public bool IsNearThePlayer()
    {
        
        return true;
    }
}
public class IdleState : BaseState
{
    public IdleState(StateManager newStateManager) : base(newStateManager)
    {
        
    }

    public override void PlayState(StateManager stateManager)
    {
        // Doing idle
        if (DoISeePlayer(stateManager)){
            stateManager.currentState = new ChaseState(stateManager);
        }
        else { Debug.Log("Where are you?"); }
    }
}
public class AttackState : BaseState
{
    public AttackState(StateManager newStateManager) : base(newStateManager)
    {
    }

    public override void PlayState(StateManager stateManager)
    {
        //Do attack
        
    }
}
public class ChaseState : BaseState
{
    public ChaseState(StateManager newStateManager) : base(newStateManager)
    {
        
    }

    public override void PlayState(StateManager stateManager)
    {
        
    }   
}



