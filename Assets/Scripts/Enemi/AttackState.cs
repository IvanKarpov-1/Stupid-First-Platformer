using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;
    private Rigidbody2D _rb;

    private void Start()
    {
        _animator = GetComponent<Animator>();  
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
        _rb.constraints = RigidbodyConstraints2D.None;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Attack(Player_old target)
    {
        int random = Random.Range(1, 3);
        _animator.Play($"Attack{random}");
        target.ApplyDamage(_damage);
    }
}
