using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetDetectedState : EnemyState
{
    public EnemyTargetDetectedState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();

        Enemy.MoveOnPointsState.ResetStartMovePoint();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsTargetInAttackRange && IsTargetDetected)
        {
            if (Enemy.AttackState.IsJustAttacked)
            {
                if (Time.time >= StartTime + EnemyData.AttackDeley)
                {
                    StateMachine.ChangeState(Enemy.AttackState);
                }
            }
            else
            {
                StateMachine.ChangeState(Enemy.AttackState);
            }
        }
        else if (!IsTargetInAttackRange && IsTargetDetected)
        {
            StateMachine.ChangeState(Enemy.TargetPursuitState);
        }
    }
}
