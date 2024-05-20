using System;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
  public event Action<Vector2> OnMoveEvent;
  public event Action<Vector2> OnLookEvent;
  public event Action OnDashEvent;
  public event Action<AttackSO> OnAttackEvent;

    protected CharacterStatHandler _statHandler;

    protected virtual void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
    }
    public void CallMoveEvent(Vector2 direction)
  {
    OnMoveEvent?.Invoke(direction);
  }

  public void CallLookEvent(Vector2 direction)
  {
    OnLookEvent?.Invoke(direction);
  }

  public void CallDashEvent()
  {
    OnDashEvent?.Invoke();
  }

  public void CallAttackEvent(AttackSO attackData)
  {
    OnAttackEvent?.Invoke(attackData);
  }
}
