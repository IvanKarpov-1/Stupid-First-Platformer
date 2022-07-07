using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(Enemy enemy, string animationBoolName) : base(enemy, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Core.Movement.SetVelocityX(0);
        Core.Movement.RB.bodyType = RigidbodyType2D.Kinematic;
        Enemy.GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
