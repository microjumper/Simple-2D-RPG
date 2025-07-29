using UnityEngine;

public class InputContext
{
    public Vector2 MoveInput { get; set; }
    public bool JumpPerformed { get; set; }
    public bool Grounded { get; set; }

    public InputContext(Vector2 moveInput, bool jumpPerformed, bool grounded)
    {
        MoveInput = moveInput;
        JumpPerformed = jumpPerformed;
        Grounded = grounded;
    }
}