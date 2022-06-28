public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsExetingState == false)
        {
            if (XInput != 0)
            {
                StateMachine.ChangeState(Player.MoveState);
            }
            else
            {
                StateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}
