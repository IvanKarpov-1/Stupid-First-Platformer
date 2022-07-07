using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CharacterStats : MonoBehaviour, IDamageable
{
    [SerializeField, Min(0)] protected float MaxHealth;
    [SerializeField, Min(0)] protected float Damage;

    [SerializeField] protected Transform AttackPoint;

    protected float CurrentHealth;

    public UnityEvent Hitted;
    public UnityEvent Died;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public virtual void ApplyDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Died.Invoke();
            return;
        }

        Hitted.Invoke();
    }

    public virtual void Attack()
    {
        
    }
}
