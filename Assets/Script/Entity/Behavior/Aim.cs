using System;
using UnityEngine;

public class Aim : MonoBehaviour
{   
    [SerializeField] private Transform _ArmPivot;

    private EntityController _controller;

    private void Awake()
    {
        _controller = GetComponent<EntityController>();
        _controller.OnLookEvent += OnAim;
    }   

    private void OnAim(Vector2 direction)
    {
        float rotZ = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;              
        _ArmPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
