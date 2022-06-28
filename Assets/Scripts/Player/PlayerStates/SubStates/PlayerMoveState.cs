public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCkecks()
    {
        base.DoCkecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsGrounded && !IsOnSlope)
        {
            Core.Movement.SetVelocityX(PlayerData.MovementVelocity * XInput);
        }
        else if (IsGrounded && IsOnSlope)
        {
            Core.Movement.SetVelocity(PlayerData.MovementVelocity * XInput, PlayerData.MovementVelocity * YInput);
        }

        if (XInput == 0 && IsExetingState == false)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
