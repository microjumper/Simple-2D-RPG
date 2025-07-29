using System;
using System.Collections.Generic;

public class StateMachine
{
    public State CurrentState { get; private set; }

    private readonly Dictionary<Type, State> states;

    public StateMachine()
    {
        states = new Dictionary<Type, State>();
    }
        
    public void RegisterState(State state)
    {
        if (state == null)
        {
            throw new ArgumentNullException(nameof(state), "State cannot be null.");       
        }

        if (!states.TryAdd(state.GetType(), state))
        {
            throw new InvalidOperationException($"State {state} is already registered.");
        }
    }
    
    public void ChangeState<T>() where T : State
    {
        var newState = GetState<T>();
        
        if (newState != CurrentState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
    
    private T GetState<T>() where T : State
    {
        if (states.TryGetValue(typeof(T), out var state))
        {
            return (T)state;
        }
        
        throw new InvalidOperationException($"State of type {typeof(T).Name} is not registered.");
    }
}