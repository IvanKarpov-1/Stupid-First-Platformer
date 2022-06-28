using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LevelAnimator : MonoBehaviour
{
    [SerializeField] private LeverSwitch _leverSwitch;
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _leverSwitch.StateSwitched.AddListener(OnStateSwitched);
    }

    private void OnStateSwitched()
    {
        _animator.SetTrigger("IsActive");
    }
}
