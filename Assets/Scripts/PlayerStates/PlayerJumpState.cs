using UnityEngine;

public class PlayerJumpState : PlayerAirborneState
{
    public PlayerJumpState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }

    public override void Enter()
    {
        Jump();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (BehaviourContext.Rigidbody.linearVelocityY < 0)
        {
            StateMachine.ChangeState<PlayerFallState>();
        }
    }
    
    private void Jump()
    {
        var gravity = Mathf.Abs(Physics2D.gravity.y * BehaviourContext.Rigidbody.gravityScale);
        var jumpVelocity = Mathf.Sqrt(2 * gravity * PlayerData.jumpHeight);
        
        BehaviourContext.Rigidbody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
    }
}