using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveOnPointsState : EnemyMoveState
{
    private bool _iStartMovePointFounded;
    private int _nextMovePoint = 0;

    public EnemyMoveOnPointsState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
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

        if (Core.Movement.FacingDirection == 1)
        {
            if (Core.Movement.RB.position.x > Enemy.Points[_nextMovePoint].Point.x)
            {
                if (_nextMovePoint == Enemy.Points.Count - 1)
                {
                    Enemy.IdleState.SetFlipAfterIdle(true);
                    _nextMovePoint--;
                }
                else
                {
                    _nextMovePoint++;
                }
                StateMachine.ChangeState(Enemy.IdleState);
            }
        }
        else
        {
            if (Core.Movement.RB.position.x < Enemy.Points[_nextMovePoint].Point.x)
            {
                if (_nextMovePoint == 0)
                {
                    Enemy.IdleState.SetFlipAfterIdle(true);
                    _nextMovePoint++;
                }
                else
                {
                    _nextMovePoint--;
                }
                StateMachine.ChangeState(Enemy.IdleState);
            }
        }
    }

    public override void DoCkecks()
    {
        base.DoCkecks();

        if (_iStartMovePointFounded == false)
        {
            FoundStartMovePoint();
        }

    }

    private void FoundStartMovePoint()
    {
        float distanceToPoint;
        float shortestDistance = float.MaxValue;

        for (int i = 0; i < Enemy.Points.Count; i++)
        {
            distanceToPoint = Vector3.Distance(Core.Movement.RB.position, Enemy.Points[i].Point);

            if (shortestDistance > distanceToPoint)
            {
                shortestDistance = distanceToPoint;
                _nextMovePoint = i;
            }
        }

        if (Core.Movement.RB.position.x < Enemy.Points[_nextMovePoint].Point.x)
        {
            if (Core.Movement.FacingDirection == -1)
            {
                Core.Movement.Flip();
            }
        }
        else
        {
            if (Core.Movement.FacingDirection == 1)
            {
                Core.Movement.Flip();
            }
        }

        _iStartMovePointFounded = true;
    }

    public void ResetStartMovePoint()
    {
        _iStartMovePointFounded = false;
    }
}
