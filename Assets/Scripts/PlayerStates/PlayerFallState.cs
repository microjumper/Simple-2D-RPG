using UnityEngine;

public class PlayerFallState : PlayerAirborneState
{
    public PlayerFallState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }

    public override void Enter()
    {
        BehaviourContext.Rigidbody.gravityScale = PlayerData.fallGravity;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (InputContext.Grounded)
        {
            if (Mathf.Abs(BehaviourContext.Rigidbody.linearVelocityX) > MovementThreshold)
            {
                StateMachine.ChangeState<PlayerRunState>();
            }
            else
            {
                StateMachine.ChangeState<PlayerIdleState>();   
            }
        }
    }
}