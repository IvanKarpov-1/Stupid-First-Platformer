using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFreeMoveState : EnemyMoveState
{
    public EnemyFreeMoveState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        IsEnteringState = true;
    }

    public override void Exit()
    {
        base.Exit();

        IsEnteringState = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (Time.time >= StartTime + EnemyData.MovementTime)
        {
            StateMachine.ChangeState(Enemy.IdleState);
        }
        else if (Core.CollisionSenses.WallFront)
        {
            Enemy.IdleState.SetFlipAfterIdle(true);
            StateMachine.ChangeState(Enemy.IdleState);
        }
    }
}
