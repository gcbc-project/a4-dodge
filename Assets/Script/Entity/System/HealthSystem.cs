using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private float _healthChangeDelay = 0.5f;
    
    public float CurrentHP { get; private set; }
    public event Action OnDamageEvent;
    public event Action OnHealEvent;
    public event Action OnDeathEvent;
    public event Action OnInvincibilityEndEvent;
    public event Action<float> OnHPChangeEvent;
    public float MaxHP => _statHandler.CurrentStat.MaxHP;

    private EnemySpawn _enemySpawn;
    private CharacterStatHandler _statHandler;
    private float _timeSinceLastChange = float.MaxValue;
    private bool _isAttacked = false;
 
    private void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
        _enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttacked && _timeSinceLastChange < _healthChangeDelay)
        {
            _timeSinceLastChange += Time.deltaTime;
            if (_timeSinceLastChange >= _healthChangeDelay)
            {
                InvincibilityEnd();
                _isAttacked = false;
            }
        }
    }

    public bool ChangeHP(float change)
    {
        if (change > 0f || _timeSinceLastChange >= _healthChangeDelay)
        {
            if(change > 0f) Heal();
            else if(_timeSinceLastChange >= _healthChangeDelay) _timeSinceLastChange = 0f;
            CurrentHP += change;
            CurrentHP = Mathf.Clamp(CurrentHP, 0f, MaxHP);

            if (change <= 0f)
            {
                Damage();
                _isAttacked = true;
            }
            OnHPChangeEvent?.Invoke(CurrentHP);
            if (CurrentHP <= 0f)
            {
                Death();
                return true;
            }
        }
        return false;
    }
    private void Death()
    {
        OnDeathEvent?.Invoke();
        if (gameObject.CompareTag("Enemy")) _enemySpawn.DestroyEnemy(gameObject);
        else GameManager.Instance.GameOver();
    }

    private void Heal()
    {
        OnHealEvent?.Invoke();
    }

    private void Damage()
    {
        OnDamageEvent?.Invoke();
    }

    private void InvincibilityEnd()
    {
        OnInvincibilityEndEvent?.Invoke();
    }
}
