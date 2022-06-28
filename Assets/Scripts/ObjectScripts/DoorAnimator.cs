using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnimator : MonoBehaviour
{
    [SerializeField] private DoorOpener _doorOpener;
    private Animator _animator;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _doorOpener.DoorOpened.AddListener(OnDoorOpened);
    }

    private void OnDoorOpened()
    {
        _animator.SetTrigger("IsOpen");
    }
}
