public class PlayerState : State
{
    protected const float MovementThreshold = 0.01f;
    
    protected MonoBehaviourContext BehaviourContext { get; }
    protected InputContext InputContext { get; }
    protected PlayerData PlayerData { get; }

    protected PlayerState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine)
    {
        BehaviourContext = behaviourContext;
        InputContext = inputContext;
        PlayerData = playerData;
    }

    public override void FixedUpdate()
    {
        BehaviourContext.Animator.SetBool(AnimatorHashes.Grounded, InputContext.Grounded);
    }
}