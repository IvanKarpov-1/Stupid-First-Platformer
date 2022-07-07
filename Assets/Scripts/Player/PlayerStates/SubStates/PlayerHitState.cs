using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
    public PlayerHitState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Core.Movement.SetVelocityX(0);

        if (Time.time > StartTime + PlayerData.StunTime)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
