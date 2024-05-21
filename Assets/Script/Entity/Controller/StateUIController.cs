using UnityEngine;
using UnityEngine.UI;

public class StateUIController : MonoBehaviour
{
    [SerializeField] private Image _healthUI;
    [SerializeField] private Image _manaUI;
    [SerializeField] private Image _dashUI;

    private CharacterStatHandler _characterStatHandler;
    private HealthSystem _healthSystem;
    private ManaSystem _manaSystem;
    private EntityController _controller;

    private bool _isDashing = false;
    private float _dashTime = 0f;

    private void Awake()
    {
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
            _dashTime += Time.fixedDeltaTime;
            _dashUI.fillAmount = _dashTime / (_characterStatHandler.CurrentStat.DashCoolTime + _characterStatHandler.CurrentStat.DashHoldTime);
            _dashUI.fillAmount = Mathf.Clamp(_dashUI.fillAmount, 0f, 1f);
            if ( _dashTime >= (_characterStatHandler.CurrentStat.DashCoolTime + _characterStatHandler.CurrentStat.DashHoldTime))
            {
                _dashTime = 0f;
                _isDashing = false;
            }
        }
    }

    private void UpdateDashUI()
    {
        if (_dashTime <= 0f)
        {
            _dashUI.fillAmount = 0f;
            _isDashing = true;
        }
    }

    private void UpdateManaUI(float currentMP)
    {
        _manaUI.fillAmount = currentMP / _manaSystem.MaxMP;
    }

    private void UpdateHealthUI(float currentHP)
    {
        _healthUI.fillAmount = currentHP / _healthSystem.MaxHP;
    }
}
