public class PlayerFallState : PlayerAirborneState
{
    public PlayerFallState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (InputContext.Grounded)
        {
            StateMachine.ChangeState<PlayerIdleState>();
        }
    }
}