using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected bool IsPursuing;

    public EnemyMoveState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsTargetDetected && !IsPursuing)
        {
            StateMachine.ChangeState(Enemy.TargetDetectedState);
        }
        else if (IsEnteringState == false && !IsPursuing)
        {
            if (EnemyData.MovementType == MovementType.FreeMove)
            {
                StateMachine.ChangeState(Enemy.FreeMoveState);
            }
            else
            {
                StateMachine.ChangeState(Enemy.MoveOnPointsState);
            }
        }
        else if (!IsOnSlope)
        {
            Core.Movement.SetVelocityX(EnemyData.MovementVelocity * Core.Movement.FacingDirection);
        }
        else if (IsOnSlope)
        {
            Core.Movement.SetVelocity(EnemyData.MovementVelocity * Core.Movement.FacingDirection);
        }
    }
}

public enum MovementType
{
    FreeMove,
    MoveOnPoints
}