public abstract class State
{
    protected readonly StateMachine StateMachine;

    protected State(StateMachine stateMachine) => StateMachine = stateMachine;
        
    public virtual void Enter() { }
    
    public virtual void Exit() { }
        
    public virtual void Update() { }
        
    public virtual void FixedUpdate() { }
}