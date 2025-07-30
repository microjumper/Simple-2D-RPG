using UnityEngine;

public class PlayerAirborneState : PlayerState
{
    protected PlayerAirborneState(StateMachine stateMachine, MonoBehaviourContext behaviourContext, InputContext inputContext, PlayerData playerData)
        : base(stateMachine, behaviourContext, inputContext, playerData) { }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        BehaviourContext.Animator.SetFloat(AnimatorHashes.yVelocity, BehaviourContext.Rigidbody.linearVelocityY);
        
        ApplyHorizontalAirborneMovement();
    }
    
    private void ApplyHorizontalAirborneMovement()
    {
        var desiredSpeed = InputContext.MoveInput.x * PlayerData.airborneSpeed;
        var currentHorizontalVelocity = BehaviourContext.Rigidbody.linearVelocityX;
        var velocityToApply = Mathf.MoveTowards(currentHorizontalVelocity, desiredSpeed, 
            PlayerData.airborneAcceleration * Time.fixedDeltaTime);
        BehaviourContext.Rigidbody.linearVelocityX = velocityToApply;
    }

}