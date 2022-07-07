public class PlayerAbilityState : PlayerState
{
    protected bool IsAbilityDone;

    private bool _isGrounded;

    public PlayerAbilityState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void DoCkecks()
    {
        base.DoCkecks();

        _isGrounded = Core.CollisionSenses.Ground;
    }

    public override void Exit()
    {
        base.Exit();

        IsAbilityDone = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsAbilityDone)
        {
            if (_isGrounded && Core.Movement.CurrentVelocity.y < 0.01f)
            {
                StateMachine.ChangeState(Player.IdleState);
            }
            else
            {
                StateMachine.ChangeState(Player.InAirState);
            }
        }
    }
}
