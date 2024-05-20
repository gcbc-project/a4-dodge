using System;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
  public event Action<Vector2> OnMoveEvent;
  public event Action<Vector2> OnLookEvent;
  public event Action OnDashEvent;
  public event Action OnAttackEvent;

  protected CharacterStatHandler _statController { get; private set; }

    protected virtual void Awake()
    { 
        _statController = GetComponent<CharacterStatHandler>();
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

  public void CallAttackEvent()
  {
    OnAttackEvent?.Invoke();
  }
}
