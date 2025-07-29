using UnityEngine;

public class GroundChecker: MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float rayLength = 0.1f;
    
    private new Collider2D collider;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
    }

    public bool IsGrounded()
    {
        var boxCastBounds = CreateBoxCastBounds();

        return Physics2D.BoxCast(boxCastBounds.boxOrigin, boxCastBounds.boxSize, 0f, Vector2.down, rayLength, groundLayer).collider;
    }
    
    private (Vector2 boxOrigin, Vector2 boxSize) CreateBoxCastBounds()
    {
        // Position the box at the bottom of the collider
        var boxOrigin = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        
        // Create a box size that matches the collider width but is thin vertically
        var boxSize = new Vector2(collider.bounds.size.x, 0.05f);
        
        return (boxOrigin, boxSize);
    }

    
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (collider == null)
        {
            collider = GetComponent<Collider2D>();
        }
    
        var (sweepStart, boxSize) = CreateBoxCastBounds();
    
        Gizmos.color = IsGrounded() ? Color.green : Color.red;
        
        // Define the start and end points of the box cast sweep
        var sweepEnd = sweepStart + Vector2.down * rayLength;
        
        // Calculate the size of the entire swept area
        var sweepSize = new Vector2(boxSize.x, boxSize.y + rayLength);
        var sweepCenter = (sweepStart + sweepEnd) * 0.5f;
        
        Gizmos.DrawWireCube(sweepCenter, sweepSize);
    }
#endif
}