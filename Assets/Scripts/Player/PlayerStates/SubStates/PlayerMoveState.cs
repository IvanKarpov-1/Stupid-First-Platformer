public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
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
            Core.Movement.SetVelocity(PlayerData.MovementVelocity * XInput, 0f);
        }

        if (XInput == 0 && IsExetingState == false)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
