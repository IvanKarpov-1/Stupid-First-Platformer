using System;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float _speed = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    private bool _isGrounded = true;
    private float _groundRadius = 0.2f;
    private bool _isAttacking = false;
    private Rigidbody2D _rb;
    private PlayerInput _playerInput;
    private PlayerAnimator _playerAnimator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        _playerInput.SpacePressing.AddListener(Jump);
        _playerInput.MovementKeysPressing.AddListener(Move);
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _whatIsGround);
        _playerAnimator.SetIsGrounded(_isGrounded);
        _playerAnimator.SetRBVelocityY(_rb.velocity.y);
    }

    private void Move(float direction)
    {
        if (direction == 0)
        {
            _playerAnimator.Idle();
        }
        else
        {
            if (_isAttacking == false)
            {
                _playerAnimator.Run();
                _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
                int flipDirection = direction > 0 ? 1 : -1;
                transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * flipDirection, transform.localScale.y, transform.localScale.z);
            }
        } 
    }

    private void Jump()
    {
        if (_isGrounded && _isAttacking == false)
        {
            _rb.AddForce(new Vector2(0, 400));
        }
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
