using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private EnemyData _enemyData;

    public override void Attack()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(AttackPoint.position, _enemyData.AttackDistance, _enemyData.WhatIsTarget);

        foreach (Collider2D collider in detectedObjects)
        {
            if (collider.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.ApplyDamage(Damage);
            }
        }
    }
}
