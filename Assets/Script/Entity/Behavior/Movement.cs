using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rgbd;
    private EntityController _controller;
    private CharacterStatHandler _characterStateHandler;

    private readonly float _speed = 240f;
    private float _dashSpeed = 1f;
    private bool _isDashing = false;
    private Vector2 _direction;

    void Start()
    {
        _controller = GetComponent<EntityController>();
        _rgbd = GetComponent<Rigidbody2D>();

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
        _rgbd.velocity = direction * _speed * _dashSpeed * Time.fixedDeltaTime;
    }
    private void ApplyDash()
    {
        if (!_isDashing)
        {
            StartCoroutine("DashTimer");
        }
        _dashSpeed = _isDashing ? 3f : 1f;
    }

    private void Move(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void Dash()
    {
        _isDashing = true;
    }

    private IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(0.3f);
        _isDashing = false;
        StopCoroutine("DashTimer");
    }
}