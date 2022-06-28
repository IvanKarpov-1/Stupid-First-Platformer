public class PlayerJumpState : PlayerAbilityState
{
    private int _amountOfJumpsLeft;

    public PlayerJumpState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
        _amountOfJumpsLeft = PlayerData.AmountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();

        Core.Movement.SetVelocityY(PlayerData.JumpVelocity);
        IsAbilityDone = true;
        _amountOfJumpsLeft--;
        Player.InAirState.SetIsJumping();
    }

    public bool CanJump()
    {
        if (_amountOfJumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetAmountOfJumpsLeft() => _amountOfJumpsLeft = PlayerData.AmountOfJumps;

    public void DecreaseAmounOfJumpsLeft() => _amountOfJumpsLeft--;
}
