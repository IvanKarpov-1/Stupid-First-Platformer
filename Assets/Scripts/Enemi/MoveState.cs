using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maximumMoveRange;
    private Animator _animator;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _animator.Play("Run");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, Target.transform.position);
        if (distance >= _maximumMoveRange)
        {
            int direction = Target.transform.position.x < transform.position.x ? -1 : 1; 
            _rb.velocity = new Vector2(direction * _speed, _rb.velocity.y);
            transform.localScale = new Vector2(Math.Abs(transform.localScale.x) * direction, transform.localScale.y);
        }
    }
}
