using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Core Core;

    protected Enemy Enemy;
    protected EnemyStateMachine StateMachine;
    protected EnemyData EnemyData;
    protected float StartTime;
    protected bool IsAnimationFinished;
    protected bool IsExetingState;
    protected bool IsEnteringState;

    protected bool IsTargetDetected;
    protected bool IsTargetInAttackRange;

    protected bool IsOnSlope;

    private readonly string _animationBoolName;

    public EnemyState(Enemy enemy, string animationBoolName)
    {
        Enemy = enemy;
        StateMachine = Enemy.StateMachine;
        EnemyData = Enemy.EnemyData;
        IsAnimationFinished = false;
        IsExetingState = false;

        _animationBoolName = animationBoolName;

        Core = Enemy.Core;

        Enemy.GetComponent<EnemyStats>().Hitted.AddListener(OnHitted);
        Enemy.GetComponent<EnemyStats>().Died.AddListener(OnDied);
    }

    public virtual void Enter()
    {
        DoCkecks();
        Enemy.Animator.SetBool(_animationBoolName, true);
        StartTime = Time.time;
        IsExetingState = false;
        //Debug.Log(_animationBoolName);
    }

    public virtual void Exit()
    {
        Enemy.Animator.SetBool(_animationBoolName, false);
        IsExetingState = true;
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        DoCkecks();
    }

    public virtual void DoCkecks()
    {
        IsTargetDetected = Enemy.CheckTargetDetected();

        if (IsTargetDetected)
        { 
            IsTargetInAttackRange = Enemy.CheckTargetInAttackRange();
        }
    }

    public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;
    public virtual void AnimationStartMovementTrigger() { }
    public virtual void AnimationStopMovementTrigger() { }

    public void OnHitted()
    {
        StateMachine.ChangeState(Enemy.HitState);
    }

    public void OnDied()
    {
        StateMachine.ChangeState(Enemy.DeathState);
    }
}
