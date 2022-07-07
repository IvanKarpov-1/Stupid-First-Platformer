using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetPursuitState : EnemyMoveState
{

    public EnemyTargetPursuitState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        IsEnteringState = true;
        IsPursuing = true;
    }

    public override void Exit()
    {
        base.Exit();

        IsEnteringState = false;
        IsPursuing = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsTargetInAttackRange)
        {
            StateMachine.ChangeState(Enemy.AttackState);
        }
        else if (!IsTargetDetected)
        {
            StateMachine.ChangeState(Enemy.IdleState);
        }
        else
        {
            Core.Movement.CheckIfShouldFlip(Enemy.CheckPersuingDirection());
        }

    }

    public override void DoCkecks()
    {
        base.DoCkecks();
    }
}
