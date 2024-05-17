using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    private EntityController _controller;
    private CharacterStatHandler _characterStateHandler;

    private float _dashTime = 0f;
    private bool _isDashing = false;
    private Vector2 _direction;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _characterStateHandler = GetComponent<CharacterStatHandler>();
        _rgbd = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _controller.OnMoveEvent += Move;
        _controller.OnDashEvent += Dash;
    }

    void FixedUpdate()
    {
        ApplyMovement(_direction);
        ApplyDash();
    }

    private void ApplyMovement(Vector2 direction)
    {
        float currentDashSpeed = _isDashing ? _characterStateHandler.CurrentStat.DashSpeed : 1f;
        _rgbd.velocity = direction * _characterStateHandler.CurrentStat.Speed * currentDashSpeed * Time.fixedDeltaTime * 100f;
    }
    private void ApplyDash()
    {
        if (_isDashing && _dashTime < _characterStateHandler.CurrentStat.DashCoolTime)
        {
            _dashTime += Time.fixedDeltaTime;
            if (_dashTime >= _characterStateHandler.CurrentStat.DashCoolTime)
            {
                _dashTime = 0f;
                _isDashing = false;
            }
        }
    }

    private void Move(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void Dash()
    {
        _isDashing = true;
    }
}