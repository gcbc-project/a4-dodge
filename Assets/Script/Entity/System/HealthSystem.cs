using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _healthChangeDelay = 0.5f; // 무적 시간 (피격 시 데미지를 무시하는 구간)
    
    public float CurrnetHP { get; private set; } // 현재 체력
    public event Action OnDamageEvent; // 피격 이벤트
    public event Action OnHealEvent; // 치유 이벤트
    public event Action OnDeathEvent; // 사망 이벤트
    public event Action OnInvincibilityEndEvent; // 무적 해제 이벤트
    public event Action<float> OnHPChangeEvent;
    public float MaxHP => _statHandler.CurrentStat.MaxHP; // 최대 채력 = 현재 스탯의 최대 채력

    private CharacterStatHandler _statHandler; // 현재 스탯 수치를 가져올 변수
    private float _timeSinceLastChange = float.MaxValue; // 초기 마지막 피격 시간을 최대치로 설정 (바로 때릴 수 있게)
    private bool _isAttacked = false; // 현재 피격 상태 초기화
 
    private void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
    }

    void Start()
    {
        CurrnetHP = MaxHP; // 첫 기동 시 현재 체력을 스탯의 최대 체력으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttacked && _timeSinceLastChange < _healthChangeDelay) // 공격받은 상태이고 딜레이 시간이 경과하지 않은 경우
        {
            _timeSinceLastChange += Time.deltaTime; // 경과 시간 업데이트
            if (_timeSinceLastChange >= _healthChangeDelay) // 딜레이 시간이 경과하면
            {
                InvincibilityEnd(); // 무적 종료 이벤트 호출
                _isAttacked = false; // 공격받은 상태 해제
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log($"데미지 + {_timeSinceLastChange}");
            ChangeHP(-10f);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log($"치유 + { _timeSinceLastChange}");
            ChangeHP(10f);
        }
    }

    public bool ChangeHP(float change) // 체력 변경 메서드
    {
        if (_isAttacked && _timeSinceLastChange < _healthChangeDelay) return false; // 데미지일 경우 딜레이 체크
        _timeSinceLastChange = 0f;
        CurrnetHP += change; // 현재 체력 변경
        CurrnetHP = Mathf.Clamp(CurrnetHP, 0f, MaxHP); // 현재 체력을 0과 최대 체력 사이로 제한
        if (CurrnetHP <= 0f) // 체력이 0 이하이면?
        {
            Death(); // 사망 이벤트 호출
            return true; // 체력 변경 성공
        }
        if (change > 0f) // 체력이 회복되는 경우
        {
            Heal(); // 치유 이벤트 호출
        }
        else if (change < 0f) // 체력이 감소되는 경우
        {
            Damage(); // 데미지 이벤트 호출
            _isAttacked = true; // 공격받은 상태로 설정
        }
        OnHPChangeEvent?.Invoke(CurrnetHP);
        return true; // 체력 변경 성공
    }

    // 이벤트 캡슐화
    private void Death()
    {
        OnDeathEvent?.Invoke();
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
