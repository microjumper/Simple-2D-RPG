using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerData", fileName = "PlayerData")]
public class PlayerData: ScriptableObject
{
    [Header("Movement")]
    [Tooltip("Player's movement speed in units per second")]
    public float movementSpeed = 5f;
    [Tooltip("Player's movement speed while airborne")]
    public float airborneSpeed = 4f;
    [Tooltip("Acceleration applied to player's movement while airborne")]
    public float airborneAcceleration = 8f;
    
    [Header("Jumping")]
    [Tooltip("Height that the player can reach when jumping")]
    public float jumpHeight = 3f;
    public float jumpGravity = 3.5f;
    public float fallGravity = 5f;
}
