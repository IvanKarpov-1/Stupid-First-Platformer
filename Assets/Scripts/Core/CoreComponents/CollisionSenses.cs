using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _wallCheckDistance;
    [SerializeField] private LayerMask _whatIsGround;

    public Transform GroundCheck 
    { 
        get => GenericNotImplementedError<Transform>.TryGet(_groundCheck, Core.transform.parent.name);
        private set => _groundCheck = value;
    }
    public Transform WallCheck 
    { 
        get => GenericNotImplementedError<Transform>.TryGet(_wallCheck, Core.transform.parent.name);
        private set => _wallCheck = value;
    }
    public float GroundCheckRadius 
    { 
        get => _groundCheckRadius; 
    }
    public float WallCheckDistance
    { 
        get => _wallCheckDistance; 
    }
    public LayerMask WhisIsGround
    { 
        get => _whatIsGround; 
    }


    public bool Ground
    {
        get => Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);
    }

    public bool WallFront
    {
        get => Physics2D.Raycast(_wallCheck.position, Vector2.right * Core.Movement.FacingDirection, _wallCheckDistance, _whatIsGround);
    }

    public bool WallBack
    {
        get => Physics2D.Raycast(_wallCheck.position, Vector2.right * -Core.Movement.FacingDirection, _wallCheckDistance, _whatIsGround);
    }
}
