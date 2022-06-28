using System.Collections;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;
    private bool _isGrounded = true;
    private bool _isAttacking = false;
    private bool _isJumping = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.PrimaryButtonPressing.AddListener(Attack);
        _playerInput.SpacePressing.AddListener(Jump);
    }

    public void Idle()
    {
        _animator.SetBool("IsRunning", false);
    }

    public void Run()
    {
        _animator.SetBool("IsRunning", true);
    }

    public void SetIsGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
        _animator.SetBool("Ground", _isGrounded);
    }

    public void SetRBVelocityY(float y)
    {
        _animator.SetFloat("ySpeed", y);
    }

    public void Jump()
    {
        if (_isGrounded && _isAttacking == false)
        {
            _animator.Play("Jump");            
        }
    }

    public void Attack()
    {
        StartCoroutine(DoAttack());
    }

    private IEnumerator DoAttack()
    {
        if (_isGrounded && _isJumping == false)
        {
            _animator.Play("Attack");
            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(0.2f);
    }

    public void JumpStart()
    {
        _isJumping = true;
    }

    public void JumpEnd()
    {
        _isJumping = false;
    }

    public void AttackStart()
    {
        _isAttacking = true;
    }

    public void AttackEnd()
    {
        _isAttacking = false;
    }
}
