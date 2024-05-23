using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    protected EntityController _controller;
    protected Vector2 _direction;
    protected virtual void  Awake()
    {
        _controller = GetComponent<EntityController>();
        _controller.OnLookEvent += Aim;
        _controller.OnAttackEvent += ExecuteAttack;
    }

    protected abstract void ExecuteAttack(AttackSO attackData);
    
    public void Aim(Vector2 direction)
    {
        _direction = direction;
    }

}
