using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : CoreComponent
{
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private float _slopeCheckDistance;
    [SerializeField] private PhysicsMaterial2D ZeroFriction;
    [SerializeField] private PhysicsMaterial2D FullFriction;

    private Vector2 _workspace;
    private Vector2 _colliderSize;
    private Vector2 _slopeNormalPerpedicular;
    private float _slopeDownAngle;
    private float _slopeDownAngleOld;
    private float _slopeSideAngle;
    private bool _isOnSlope;

    public Rigidbody2D RB { get; private set; }
    public CapsuleCollider2D CC { get; private set; }
    public int FacingDirection { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }


    protected override void Awake()
    {
        base.Awake();

        RB = GetComponentInParent<Rigidbody2D>();
        CC = GetComponentInParent<CapsuleCollider2D>();

        _colliderSize = CC.size;
        FacingDirection = 1;
    }

    public void LogicUpdate()
    {
        CurrentVelocity = RB.velocity;
    }

    #region Set Functions
    public void SetVelocityX(float velocity)
    {
        _workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void SetVelocityY(float velocity)
    {
        _workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = _workspace;
        CurrentVelocity = _workspace;
    }

    public void SetVelocity(float velocityX, float velocityY = 0f)
    {
        _workspace.Set(-velocityX * _slopeNormalPerpedicular.x, -velocityY * _slopeNormalPerpedicular.y);
        RB.velocity = _workspace;
        CurrentVelocity = _workspace;
    }
    #endregion


    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }

    public void Flip()
    {
        FacingDirection *= -1;
        RB.transform.Rotate(0.0f, 180.0f, 0, 0f);
    }

    public bool SlopeCheck(int xInput)
    {
        Vector2 checkPosition = transform.position - new Vector3(0.0f, _colliderSize.y / 2);

        SlopeCheckHorizontal(checkPosition);
        SlopeCheckVertical(checkPosition, xInput);

        return _isOnSlope;
    }

    private void SlopeCheckHorizontal(Vector2 checkPosition)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPosition, transform.right, _slopeCheckDistance, _whatIsGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPosition, -transform.right, _slopeCheckDistance, _whatIsGround);

        if (slopeHitFront)
        {
            _isOnSlope = true;
            _slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            _isOnSlope = true;
            _slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }
        else
        {
            _slopeSideAngle = 0.0f;
            _isOnSlope = false;
        }
    }

    private void SlopeCheckVertical(Vector2 checkPosition, int xInput)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, _slopeCheckDistance, _whatIsGround);

        if (hit)
        {
            _slopeNormalPerpedicular = Vector2.Perpendicular(hit.normal).normalized;
            _slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (_slopeDownAngle != _slopeDownAngleOld)
            {
                _isOnSlope = true;
            }

            _slopeDownAngleOld = _slopeDownAngle;

            Debug.DrawRay(hit.point, _slopeNormalPerpedicular, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }

        if (_isOnSlope && xInput == 0)
        {
            RB.sharedMaterial = FullFriction;
        }
        else
        {
            RB.sharedMaterial = ZeroFriction;
        }
    }
}
