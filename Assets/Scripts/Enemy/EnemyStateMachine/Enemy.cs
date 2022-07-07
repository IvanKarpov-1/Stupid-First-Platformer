using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region State Variables
    [SerializeField] private EnemyData _enemyData;

    public EnemyData EnemyData { get => _enemyData; }

    public EnemyStateMachine StateMachine { get; private set; }

    public EnemyIdleState IdleState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }
    public EnemyFreeMoveState FreeMoveState { get; private set; }
    public EnemyMoveOnPointsState MoveOnPointsState { get; private set; }
    public EnemyTargetDetectedState TargetDetectedState { get; private set; }
    public EnemyTargetPursuitState TargetPursuitState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }
    public EnemyHitState HitState { get; private set; }
    public EnemyDeathState DeathState { get; private set; }
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Animator { get; private set; }
    #endregion

    #region Other Variables
    [SerializeField] private List<PointToMove> _points;
    [SerializeField] private Transform _targetCheck;
    [SerializeField] private Transform _attackPoint;

    public List<PointToMove> Points { get => _points; }
    #endregion

    private void Awake()
    {
        Core = GetComponentInChildren<Core>();
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, "idle");
        MoveState = new EnemyMoveState(this, "move");
        FreeMoveState = new EnemyFreeMoveState(this, "move");
        MoveOnPointsState = new EnemyMoveOnPointsState(this, "move");
        TargetDetectedState = new EnemyTargetDetectedState(this, "targetDetected");
        TargetPursuitState = new EnemyTargetPursuitState(this, "move");
        AttackState = new EnemyAttackState(this, "attack1");
        HitState = new EnemyHitState(this, "hit");
        DeathState = new EnemyDeathState(this, "death");
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();

        StateMachine.Init(IdleState);
    }

    private void Update()
    {
        Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public bool CheckTargetDetected()
    {
        return Physics2D.OverlapCircle(_targetCheck.position, _enemyData.DetectingDistance, _enemyData.WhatIsTarget);
    }

    public bool CheckTargetInAttackRange()
    {
        return Physics2D.OverlapCircle(_attackPoint.position, _enemyData.AttackDistance, _enemyData.WhatIsTarget);
    }

    public int CheckPersuingDirection()
    {
        if (CheckTargetDetected() == false)
        {
            return 0;
        }

        float targetPosition = Physics2D.OverlapCircle(_targetCheck.position, _enemyData.DetectingDistance, _enemyData.WhatIsTarget).transform.position.x;
        if (targetPosition < transform.position.x)
        {
            return -1;
        }
        else if (targetPosition > transform.position.x)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void OnDrawGizmos()
    {
        if (Core != null)
        {
            Gizmos.DrawLine(Core.CollisionSenses.WallCheck.position, Core.CollisionSenses.WallCheck.position + (Vector3)(Core.CollisionSenses.WallCheckDistance * Core.Movement.FacingDirection * Vector2.right));

            Gizmos.DrawWireSphere(_targetCheck.position, _enemyData.DetectingDistance);
            Gizmos.DrawWireSphere(_attackPoint.position, _enemyData.AttackDistance);
        }

    }

    #region Triggers
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void AnimationStartMovementTrigger() => StateMachine.CurrentState.AnimationStartMovementTrigger();
    private void AnimationStopMovementTrigger() => StateMachine.CurrentState.AnimationStopMovementTrigger();
    #endregion
}
