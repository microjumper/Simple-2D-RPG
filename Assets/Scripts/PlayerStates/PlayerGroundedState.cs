using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected const float MovementThreshold = 0.01f;
    
    protected PlayerGroundedState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        BehaviourContext.Rigidbody.linearVelocityX = InputContext.MoveInput.x * PlayerData.movementSpeed;
        
        if (InputContext.Grounded && InputContext.JumpPerformed)
        {
            BehaviourContext.Rigidbody.AddForce(Vector2.up * PlayerData.jumpForce, ForceMode2D.Impulse);
            
            StateMachine.ChangeState<PlayerJumpState>();
        }
    }
}