using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitState : EnemyState
{
    public EnemyHitState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Core.Movement.SetVelocityX(0);

        if (Time.time > StartTime + EnemyData.StunTime)
        {
            StateMachine.ChangeState(Enemy.IdleState);
        }
    }
}
