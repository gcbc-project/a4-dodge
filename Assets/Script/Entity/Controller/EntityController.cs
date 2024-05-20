using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnDashEvent;
    public event Action<AttackSO> OnAttackEvent;

    protected CharacterStatHandler _statHandler;

    protected bool isAttacking { get; set; }
    private float timeSinceLastAttack = float.MaxValue;

    protected virtual void Awake()
    {
        _statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < _statHandler.CurrentStat.AttackData.CoolTime)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (isAttacking && timeSinceLastAttack >= _statHandler.CurrentStat.AttackData.CoolTime)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(_statHandler.CurrentStat.AttackData);
        }
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
