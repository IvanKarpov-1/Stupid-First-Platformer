using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DeathState : State
{
    private Animator _animator;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _animator.Play("Death");
        _rb.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        this.enabled = false;
    }
}
