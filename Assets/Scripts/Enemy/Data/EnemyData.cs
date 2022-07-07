using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data", order = 51)]
public class EnemyData : ScriptableObject
{
    [Header("IdleState")]
    public float IdleTime = 10f;

    [Header("Move State")]
    public float MovementVelocity = 10f;
    public float MovementTime = 10f;
    public LinkedList<PointToMove> Points;
    public MovementType MovementType;

    [Header("Attack State")]
    public LayerMask WhatIsTarget;
    public float AttackVelocity = 5f;
    public float AttackDeley = 1f;
    public float DetectingDistance = 5f;
    public float AttackDistance = 1f;

    [Header("Hit State")]
    public float StunTime = 0.5f;
}
