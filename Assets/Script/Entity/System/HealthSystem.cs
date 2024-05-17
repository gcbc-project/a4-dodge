using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _healthChangeDelay = 0.5f; // 무적 시간 (피격 시 데미지를 무시하는 구간)
    
    private CharacterStatHandler _statHandler; // 현재 스탯 수치를 가져올 변수
    private float _timeSinceLastChange = float.MaxValue; // 초기 마지막 피격 시간을 최대치로 설정 (바로 때릴 수 있게)
    private bool _isAttacked = false; // 현재 피격 상태 초기화
 
    public float CurrnetHP { get; private set; } // 현재 체력
    public event Action OnDamageEvent; // 피격 이벤트
    public event Action OnHealEvent; // 치유 이벤트
    public event Action OnDeathEvent; // 사망 이벤트
    public event Action OnInvincibilityEndEvent; // 무적 해제 이벤트
    public float MaxHP => _statHandler.CurrenStat.MaxHP; // 최대 채력 = 현재 스탯의 최대 채력

    private void Awake()
    {
        
    }

    void Start()
    {
        CurrnetHP = MaxHP; // 첫 기동 시 현재 체력을 스탯의 최대 체력으로 초기화
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttacked && _timeSinceLastChange < _healthChangeDelay) // 마지막 피격 시간이 무적 시간 이내인 경우 (무적 시간 발동 중)
        {
            _timeSinceLastChange += Time.deltaTime; // 마지막 피격 시간 증가
            if (_timeSinceLastChange > _healthChangeDelay) // 마지막 피격 시간이 무적 시간을 넘어간 경우
            {
                InvincibilityEnd(); // 무적 해제 이벤트 호출
                _isAttacked = false; // 피격 상태 해제
            }
        }
    }

    public bool ChangeHP(float change) // 체력 증감 메서드
    {
        if (_timeSinceLastChange < _healthChangeDelay) return false; // 무적 상태인가? 체력 변경 안함

        _timeSinceLastChange = 0f;
        CurrnetHP += change; // 현재 체력 증감 (양수 : 치유, 음수 : 데미지)
        CurrnetHP = Mathf.Clamp(CurrnetHP, 0f, MaxHP); // 현재 체력값을 0 ~ 최대치 사이의 값으로 변환 (0 미만일 경우 0, 최대치 초과일 경우 최대치)

        if (CurrnetHP <= 0f) // 체력 변경후 값이 0 이하인가? (죽었는가?)
        {
            Death(); // 사망 이벤트 호출
            return true; // 체력 변경 했음
        }
        if (change >= 0f) // 변경 값이 양수인가? (치유)
        {
            Heal(); // 치유 이벤트 호출
        }
        else // 아닌가? (현재 체력 0 초과 && 변경값 음수)
        {
            Damage(); // 데미지 이벤트 호출
            _isAttacked = true; // 현재 피격 상태 설정
        }
        return true; // 체력 변경 했음
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
