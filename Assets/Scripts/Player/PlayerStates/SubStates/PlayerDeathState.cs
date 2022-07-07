using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Core.Movement.SetVelocityX(0);
        Core.Movement.RB.bodyType = RigidbodyType2D.Kinematic;
        Player.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
