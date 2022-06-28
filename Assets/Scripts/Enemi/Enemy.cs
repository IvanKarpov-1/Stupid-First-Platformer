using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _rewardExperience;
    [SerializeField] private Player_old _target;
    private int _currentHealth;
    private Animator _animator;

    public UnityEvent Dying;
    public Player_old Target => _target;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _animator.StopPlayback();
        _animator.Play("Hit");
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        RewardSystem.instance.EnemyDying?.Invoke(_rewardExperience);
        Dying?.Invoke();
    }
}
