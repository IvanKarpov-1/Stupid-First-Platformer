using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected bool FlipAfterIdle;

    public EnemyIdleState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();

        if (FlipAfterIdle)
        {
            Core.Movement.Flip();
        }

        FlipAfterIdle = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Core.Movement.SetVelocityX(0f);

        if (IsTargetDetected)
        {
            StateMachine.ChangeState(Enemy.TargetDetectedState);
        }
        else if (Time.time >= StartTime + EnemyData.IdleTime)
        {
            StateMachine.ChangeState(Enemy.MoveState);
        }
    }

    public void SetFlipAfterIdle(bool isFlip)
    {
        FlipAfterIdle = isFlip;
    }
}
