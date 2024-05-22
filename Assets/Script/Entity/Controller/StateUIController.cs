using UnityEngine;
using UnityEngine.UI;

public class StateUIController : MonoBehaviour
{
    [SerializeField] private Image _healthUI;
    [SerializeField] private Image _manaUI;
    [SerializeField] private Image _dashUI;

    private Movement _movement;
    private CharacterStatHandler _characterStatHandler;
    private HealthSystem _healthSystem;
    private ManaSystem _manaSystem;

    private bool _isDashing = false;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _characterStatHandler = GetComponent<CharacterStatHandler>();
        _healthSystem = GetComponent<HealthSystem>();
        _manaSystem = GetComponent<ManaSystem>();

        _healthSystem.OnHPChangeEvent += UpdateHealthUI;

        _manaSystem.OnMPChanged += UpdateManaUI;

        _movement.OnDashEvent += UpdateDashUI;
    }

    private void UpdateDashUI(float dashTime)
    {
        if (dashTime <= 0f || dashTime == float.MaxValue)
        {
            _dashUI.color = Color.white;
            _dashUI.fillAmount = 0f;
            _isDashing = true;
        }

        if (_isDashing)
        {
            _dashUI.fillAmount = dashTime / (_characterStatHandler.CurrentStat.DashCoolTime + _characterStatHandler.CurrentStat.DashHoldTime);
            _dashUI.fillAmount = Mathf.Clamp(_dashUI.fillAmount, 0f, 1f);
            if (dashTime >= (_characterStatHandler.CurrentStat.DashCoolTime + _characterStatHandler.CurrentStat.DashHoldTime))
            {
                _isDashing = false;
                _dashUI.color = Color.yellow;
            }
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
