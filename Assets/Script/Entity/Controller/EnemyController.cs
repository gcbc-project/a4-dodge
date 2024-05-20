using UnityEngine;

public class EnemyController : EntityController
{
    GameManager gameManager;
    protected Transform TargetPos { get; private set; }
    [SerializeField][Range(0f, 100f)] protected float _followRange;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        TargetPos = gameManager.Player;
    }

    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, TargetPos.position);
    }

    protected Vector2 DirectionToTarget()
    {
        return (TargetPos.position - transform.position).normalized;
    }   
}
