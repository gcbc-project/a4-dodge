using System;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform _armPivot;
    [SerializeField] private Transform _entityPivot;

    private EntityController _controller;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        float rotZ = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector2 scale = _entityPivot.localScale;
        scale.x = Mathf.Abs(rotZ) > 90f ? -1f : 1f;
        _entityPivot.localScale = scale;
        _armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
