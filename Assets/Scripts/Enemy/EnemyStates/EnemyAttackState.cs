using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private float _velocityToSet;
    private bool _setVelocity;

    public bool IsJustAttacked { get; private set; }

    public EnemyAttackState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        _setVelocity = false;
        IsAnimationFinished = false;
        IsJustAttacked = false;
    }

    public override void Exit()
    {
        base.Exit();

        IsJustAttacked = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Core.Movement.CheckIfShouldFlip(Enemy.CheckPersuingDirection());

        if (_setVelocity)
        {
            Core.Movement.SetVelocityX(_velocityToSet * Core.Movement.FacingDirection);
            _setVelocity = false;
        }
        else if (IsAnimationFinished)
        {
            if (IsTargetDetected)
            {
                StateMachine.ChangeState(Enemy.TargetDetectedState);
            }
            else
            {
                StateMachine.ChangeState(Enemy.MoveState);
            }
        }
    }

    public void SetEnemyVelocity(float velocity)
    {
        Core.Movement.SetVelocityX(velocity * Core.Movement.FacingDirection);

        _velocityToSet = velocity;
        _setVelocity = true;
    }

    public override void AnimationStartMovementTrigger()
    {
        base.AnimationStartMovementTrigger();

        SetEnemyVelocity(EnemyData.AttackVelocity);
    }

    public override void AnimationStopMovementTrigger()
    {
        base.AnimationStopMovementTrigger();

        SetEnemyVelocity(0f);
    }

}
