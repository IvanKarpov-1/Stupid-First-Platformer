using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private float _velocityToSet;
    private bool _setVelocity;
    private int _xInput;

    public PlayerAttackState(Player player, string animationBoolName) : base(player, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _setVelocity = false;

        IsAbilityDone = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _xInput = Player.InputHandler.NormInputX;

        Core.Movement.CheckIfShouldFlip(_xInput);

        if (_setVelocity)
        {
            Core.Movement.SetVelocityX(_velocityToSet * Core.Movement.FacingDirection);
            _setVelocity = false;
        }
    }

    public void SetPlayerVelocity(float velocity)
    {
        Core.Movement.SetVelocityX(velocity * Core.Movement.FacingDirection);

        _velocityToSet = velocity;
        _setVelocity = true;
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();

        IsAbilityDone = true;
    }

    public override void AnimationStartMovementTrigger()
    {
        base.AnimationStartMovementTrigger();

        SetPlayerVelocity(PlayerData.AttackVelocity);
    }

    public override void AnimationStopMovementTrigger()
    {
        base.AnimationStopMovementTrigger();

        SetPlayerVelocity(0f);
    }
}
