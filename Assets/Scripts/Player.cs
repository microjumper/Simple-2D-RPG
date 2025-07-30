using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GroundChecker))]
public class Player : MonoBehaviour
{
    // References to components
    private new Rigidbody2D rigidbody;
    private Animator animator;

    private GroundChecker groundChecker;

    [SerializeField]
    private PlayerData playerData;
    
    private InputAction moveAction;
    private InputAction jumpAction; 
    
    private InputContext inputContext;
    
    private StateMachine stateMachine;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        
        groundChecker = GetComponent<GroundChecker>();
    }    
    
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        
        inputContext = new InputContext(Vector2.zero, false,true);
        
        InitializeStateMachine();
    }
    
    private void Update()
    {
        inputContext.MoveInput = moveAction.ReadValue<Vector2>();
        
        inputContext.JumpPressed = jumpAction.WasPressedThisFrame();
        
        stateMachine.CurrentState?.Update();
    }
    
    private void FixedUpdate() 
    {
        inputContext.Grounded = groundChecker.IsGrounded();
        
        stateMachine.CurrentState?.FixedUpdate();
    }

    private void InitializeStateMachine()
    {
        var monoBehaviourContext = new MonoBehaviourContext(transform, rigidbody, animator);
        
        stateMachine = new StateMachine();
        
        stateMachine.RegisterState(new PlayerIdleState(stateMachine, monoBehaviourContext, inputContext, playerData));
        stateMachine.RegisterState(new PlayerRunState(stateMachine, monoBehaviourContext, inputContext, playerData));
        stateMachine.RegisterState(new PlayerJumpState(stateMachine, monoBehaviourContext, inputContext, playerData));
        stateMachine.RegisterState(new PlayerFallState(stateMachine, monoBehaviourContext, inputContext, playerData));;
        
        stateMachine.ChangeState<PlayerIdleState>();
    }
}
