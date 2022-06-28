public class PlayerGroundedState : PlayerState
{
    protected int XInput;
    protected int YInput;
    protected bool IsGrounded;
    protected bool IsOnSlope;

    private bool _jumpInput;

    public PlayerGroundedState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCkecks()
    {
        base.DoCkecks();

        IsGrounded = Core.CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();

        Player.JumpState.ResetAmountOfJumpsLeft();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        XInput = Player.InputHandler.NormInputX;
        YInput = Player.InputHandler.NormInputY;
        _jumpInput = Player.InputHandler.JumpInput;
        IsOnSlope = Core.Movement.SlopeCheck(XInput);
        Core.Movement.CheckIfShouldFlip(XInput);

        if (Player.InputHandler.AttackInput)
        {
            StateMachine.ChangeState(Player.AttackState);
        }
        else if (_jumpInput && Player.JumpState.CanJump())
        {
            Player.InputHandler.UseJumpInput();
            StateMachine.ChangeState(Player.JumpState);
        }
        else if (!IsGrounded)
        {
            Player.InAirState.StartCoyoteTime();
            StateMachine.ChangeState(Player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
