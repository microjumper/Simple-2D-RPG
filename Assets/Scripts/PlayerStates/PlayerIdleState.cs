using System;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }
    
    public override void Enter()
    {
        base.Enter();
        
        BehaviourContext.Animator.SetBool(AnimatorHashes.Idle, true);
    }

    public override void Exit()
    {
        base.Exit();

        BehaviourContext.Animator.SetBool(AnimatorHashes.Idle, false);
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (Math.Abs(BehaviourContext.Rigidbody.linearVelocity.x) > MovementThreshold)
        {
            StateMachine.ChangeState<PlayerRunState>();
        }
    }
}