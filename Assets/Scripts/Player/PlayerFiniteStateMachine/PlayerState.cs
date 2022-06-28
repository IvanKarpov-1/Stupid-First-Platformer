using UnityEngine;

public class PlayerState
{
    protected Core Core;

    protected Player Player;
    protected PlayerStateMachine StateMachine;
    protected PlayerData PlayerData;
    protected float StartTime;
    protected bool IsAnimationFinished;
    protected bool IsExetingState;

    private string _animationBoolName;

    public PlayerState(Player player, string animationBoolName)
    {
        Player = player;
        StateMachine = Player.StateMachine;
        PlayerData = Player.PlayerData;
        IsAnimationFinished = false;
        IsExetingState = false;

        _animationBoolName = animationBoolName;

        Core = Player.Core;
    }

    public virtual void Enter()
    {
        DoCkecks();
        Player.Animator.SetBool(_animationBoolName, true);
        StartTime = Time.time;
        IsExetingState = false;
    }

    public virtual void Exit()
    {
        Player.Animator.SetBool(_animationBoolName, false);
        IsExetingState = true;
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate()
    {
        DoCkecks();
    }

    public virtual void DoCkecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => IsAnimationFinished = true;

    public virtual void AnimationStartMovementTrigger() { }
    public virtual void AnimationStopMovementTrigger() { }
}
