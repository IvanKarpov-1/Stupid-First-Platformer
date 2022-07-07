using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField, ] private LayerMask _whatIsEnemy;
    [SerializeField, Min(0)] private float _attackRadius;

    public override void Attack()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(AttackPoint.position, _attackRadius, _whatIsEnemy);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(Damage);
            }
        }
    }
}
