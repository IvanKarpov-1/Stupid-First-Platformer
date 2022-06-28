using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _whatIsGround;

    public bool Ground
    {
        get => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);
    }
}
