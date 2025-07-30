using UnityEngine;

public class InputContext
{
    public Vector2 MoveInput { get; set; }
    public bool JumpPressed { get; set; }
    public bool Grounded { get; set; }

    public InputContext(Vector2 moveInput, bool jumpPressed, bool grounded)
    {
        MoveInput = moveInput;
        JumpPressed = jumpPressed;
        Grounded = grounded;
    }
}