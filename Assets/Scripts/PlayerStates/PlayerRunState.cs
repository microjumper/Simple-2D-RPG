using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    public PlayerRunState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }
    
    public override void Enter()
    {
        base.Enter();
        
        BehaviourContext.Rigidbody.linearVelocityX = 0;

        BehaviourContext.Animator.SetBool(AnimatorHashes.Running, true);
    }

    public override void Exit()
    {
        base.Exit();

        BehaviourContext.Animator.SetBool(AnimatorHashes.Running, false);
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (Mathf.Abs(BehaviourContext.Rigidbody.linearVelocityX) < MovementThreshold)
        {
            StateMachine.ChangeState<PlayerIdleState>();
        }
        else
        {
            BehaviourContext.Transform.localScale = new Vector3(Mathf.Sign(BehaviourContext.Rigidbody.linearVelocityX), 1, 1);  // Flip the player
        }
    }
}