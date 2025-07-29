using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/PlayerData", fileName = "PlayerData")]
public class PlayerData: ScriptableObject
{
    [Header("Movement")]
    [Tooltip("Player's movement speed in units per second")]
    public float movementSpeed = 5f;

    [Header("Jumping")]
    [Tooltip("Force applied when the player jumps")]
    public float jumpForce = 10f;
}
