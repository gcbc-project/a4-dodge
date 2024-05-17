using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        if (direction != null)
        {
            CallMoveEvent(direction);
        }
    }

    private void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);

        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);        
    }

    private void OnDash(InputValue value)
    {
        Debug.Log("Shift");
    }

    private void OnAttack(InputValue value)
    {
        CallAttackEvent();
    }
}
