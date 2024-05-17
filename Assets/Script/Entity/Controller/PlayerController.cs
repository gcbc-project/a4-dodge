using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
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
        Debug.Log("마우스 움직임");
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
