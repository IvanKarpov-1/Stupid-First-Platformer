using UnityEngine;
using UnityEngine.Events;

public class Player_old : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _damage = 15;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLayers;
    private int _currentHealth;
    private int _currentExperience;
    private int _levelExperience;
    private int _level;
    public UnityEvent Dying;
    public UnityEvent<int> HealthChanged;
    public UnityEvent<int> LevelChanged;
    public UnityEvent<int> ExperienceChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        RewardSystem.instance.EnemyDying.AddListener(OnEnemyDied);
        HealthChanged.Invoke(_currentHealth);
        LevelChanged.Invoke(_level);
        ExperienceChanged.Invoke(_currentExperience);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void OnEnemyDied(int experience)
    {
        _currentExperience += experience;
        ExperienceChanged.Invoke(_currentExperience);
        TryRiseLevel();
    }

    private void TryRiseLevel()
    {
        if (_currentExperience * _level >= _levelExperience)
        {
            _level += 1;
            LevelChanged.Invoke(_level);
        }
    }

    public void DoAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

        foreach (var enemy in enemies)
        {
            if (enemy is BoxCollider2D)
                enemy.GetComponent<Enemy>().ApplyDamage(_damage);
        }
    }
}
