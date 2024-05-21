using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public float DashTime = float.MaxValue;
    
    private Rigidbody2D _rgbd;
    private EntityController _controller;
    private CharacterStatHandler _characterStateHandler;

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
        if (_isDashing && DashTime < _characterStateHandler.CurrentStat.DashHoldTime)
        {
            DashTime += Time.fixedDeltaTime;
            if (DashTime >= _characterStateHandler.CurrentStat.DashHoldTime)
            {
                _isDashing = false;
            }
        }
        if (!_isDashing)
        {
            DashTime += Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void Dash()
    {
        if (DashTime >= _characterStateHandler.CurrentStat.DashCoolTime + _characterStateHandler.CurrentStat.DashHoldTime)
        {
            DashTime = 0f;
            _isDashing = true;
        }
    }
}