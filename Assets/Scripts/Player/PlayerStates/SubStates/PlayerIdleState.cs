public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCkecks()
    {
        base.DoCkecks();
    }

    public override void Enter()
    {
        base.Enter();
        Core.Movement.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (XInput != 0 && IsExetingState == false)
        {
            Core.Movement.CheckIfShouldFlip(XInput);

            StateMachine.ChangeState(Player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
