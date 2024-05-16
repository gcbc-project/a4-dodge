using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : EntityController
{
    public void OnMove(InputValue value)
    {
        Debug.Log("움직임");
    }

    public void OnLook(InputValue value)
    {
        Debug.Log("마우스 움직임");
    }

    public void OnDash(InputValue value)
    {
        Debug.Log("Shift");
    }

    public void OnAttack(InputValue value)
    {
        Debug.Log("공격");
    }
}
