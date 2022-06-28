using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    public State TargetState => _targetState;
    protected Player_old Target { get; private set; }
    public bool NeedTransit { get; protected set; }

    public void Init(Player_old target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
