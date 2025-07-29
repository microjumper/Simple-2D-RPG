public class PlayerJumpState : PlayerAirborneState
{
    public PlayerJumpState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (BehaviourContext.Rigidbody.linearVelocityY < 0)
        {
            StateMachine.ChangeState<PlayerFallState>();
        }
    }
}