using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _healthChangeDelay = 0.5f; // ���� �ð� (�ǰ� �� �������� �����ϴ� ����)
    
    public float CurrnetHP { get; private set; } // ���� ü��
    public event Action OnDamageEvent; // �ǰ� �̺�Ʈ
    public event Action OnHealEvent; // ġ�� �̺�Ʈ
    public event Action OnDeathEvent; // ��� �̺�Ʈ
    public event Action OnInvincibilityEndEvent; // ���� ���� �̺�Ʈ
    public float MaxHP => _statHandler.CurrentStat.MaxHP; // �ִ� ä�� = ���� ������ �ִ� ä��

    private CharacterStatHandler _statHandler; // ���� ���� ��ġ�� ������ ����
    private float _timeSinceLastChange = float.MaxValue; // �ʱ� ������ �ǰ� �ð��� �ִ�ġ�� ���� (�ٷ� ���� �� �ְ�)
    private bool _isAttacked = false; // ���� �ǰ� ���� �ʱ�ȭ
 
    private void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
    }

    void Start()
    {
        CurrnetHP = MaxHP; // ù �⵿ �� ���� ü���� ������ �ִ� ü������ �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttacked && _timeSinceLastChange < _healthChangeDelay) // ������ �ǰ� �ð��� ���� �ð� �̳��� ��� (���� �ð� �ߵ� ��)
        {
            _timeSinceLastChange += Time.deltaTime; // ������ �ǰ� �ð� ����
            if (_timeSinceLastChange > _healthChangeDelay) // ������ �ǰ� �ð��� ���� �ð��� �Ѿ ���
            {
                InvincibilityEnd(); // ���� ���� �̺�Ʈ ȣ��
                _isAttacked = false; // �ǰ� ���� ����
            }
        }
    }

    public bool ChangeHP(float change) // ü�� ���� �޼���
    {
        if (_timeSinceLastChange < _healthChangeDelay) return false; // ���� �����ΰ�? ü�� ���� ����

        _timeSinceLastChange = 0f;
        CurrnetHP += change; // ���� ü�� ���� (��� : ġ��, ���� : ������)
        CurrnetHP = Mathf.Clamp(CurrnetHP, 0f, MaxHP); // ���� ü�°��� 0 ~ �ִ�ġ ������ ������ ��ȯ (0 �̸��� ��� 0, �ִ�ġ �ʰ��� ��� �ִ�ġ)

        if (CurrnetHP <= 0f) // ü�� ������ ���� 0 �����ΰ�? (�׾��°�?)
        {
            Death(); // ��� �̺�Ʈ ȣ��
            return true; // ü�� ���� ����
        }
        if (change >= 0f) // ���� ���� ����ΰ�? (ġ��)
        {
            Heal(); // ġ�� �̺�Ʈ ȣ��
        }
        else // �ƴѰ�? (���� ü�� 0 �ʰ� && ���氪 ����)
        {
            Damage(); // ������ �̺�Ʈ ȣ��
            _isAttacked = true; // ���� �ǰ� ���� ����
        }
        return true; // ü�� ���� ����
    }

    // �̺�Ʈ ĸ��ȭ
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
