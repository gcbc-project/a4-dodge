using UnityEngine;

public class EnemyController : EntityController
{    
    protected Transform _targetPos { get; private set; }
    [SerializeField][Range(0f, 100f)] protected float _followRange;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {        
        _targetPos = GameManager.Instance.Player;
    }

    protected float DistanceToTarget()
    {
        return Vector2.Distance(transform.position, _targetPos.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (_targetPos.position - transform.position).normalized;
    }   
}
