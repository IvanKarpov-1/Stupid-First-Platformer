using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data", order = 51)]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float MovementVelocity = 10f;

    [Header("Jump State")]
    public float JumpVelocity = 15f;
    public int AmountOfJumps = 1;

    [Header("In Air State")]
    public float CoyoteTime = 0.2f;
    public float VariableJumpHeightMultiplier = 0.5f;

    [Header("Attack State")]
    public float AttackVelocity = 5f;
}
