using UnityEngine;
using UnityEngine.UI;

public class StateUIController : MonoBehaviour
{
    [SerializeField] private Image _healthUI;
    [SerializeField] private Image _ManaUI;
    [SerializeField] private Image _DashUI;
    private Movement _movement;

    private CharacterStatHandler _characterStatHandler;
    private HealthSystem _healthSystem;
    private ManaSystem _manaSystem;
    private EntityController _controller;

    private bool _isDashing = false;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _characterStatHandler = GetComponent<CharacterStatHandler>();
        _healthSystem = GetComponent<HealthSystem>();
        _manaSystem = GetComponent<ManaSystem>();
        _controller = GetComponent<EntityController>();

        _healthSystem.OnHPChangeEvent += UpdateHealthUI;

        _manaSystem.OnMPChanged += UpdateManaUI;

        _controller.OnDashEvent += UpdateDashUI;
    }

    private void FixedUpdate()
    {
        if (_isDashing)
        {
            _DashUI.fillAmount = _movement.DashTime / (_characterStatHandler.CurrentStat.DashCoolTime + _characterStatHandler.CurrentStat.DashHoldTime);
            _DashUI.fillAmount = Mathf.Clamp(_DashUI.fillAmount, 0f, 1f);
            if (_movement.DashTime >= (_characterStatHandler.CurrentStat.DashCoolTime + _characterStatHandler.CurrentStat.DashHoldTime))
            {
                _isDashing = false;
            }
        }
    }

    private void UpdateDashUI()
    {
        if (_movement.DashTime <= 0f)
        {
            _isDashing = true;
        }
    }

    private void UpdateManaUI(float currentMP)
    {
        _ManaUI.fillAmount = currentMP / _manaSystem.MaxMP;
    }

    private void UpdateHealthUI(float currentHP)
    {
        _healthUI.fillAmount = currentHP / _healthSystem.MaxHP;
    }
}
