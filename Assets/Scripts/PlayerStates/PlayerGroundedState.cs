using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected PlayerGroundedState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }

    public override void Enter()
    {
        BehaviourContext.Rigidbody.gravityScale = PlayerData.jumpGravity;
    }

    public override void Update()
    {
        base.Update();
        
        if (InputContext.Grounded && InputContext.JumpPressed)
        {
            StateMachine.ChangeState<PlayerJumpState>();
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        BehaviourContext.Rigidbody.linearVelocityX = InputContext.MoveInput.x * PlayerData.movementSpeed;
    }
}