using System;
using UnityEngine;

public class EnemyRangeController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float _shootRange;
    private int _layerMaskTarget;    

    protected override void Start()
    {
        base.Start();
        _layerMaskTarget = _statController.CurrentStat.AttackData.Target;
    }
        
    void FixedUpdate()
    {
        float distanceToTarget = DistanceToTarget();
        Vector2 directionToTarget = DirectionToTarget();

        UpdateState(distanceToTarget, directionToTarget);
    }

    private void UpdateState(float distance, Vector2 direction)
    {

        if (distance <= _followRange)
        {
            CheckIfNear(distance, direction);
        }
    }

    private void CheckIfNear(float distance, Vector2 direction)
    {
        if (distance <= _shootRange)
        {
            TryShootAtTarget(direction);
        }
        else
        {
            CallMoveEvent(direction);
        }
    }

    private void TryShootAtTarget(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _shootRange, _layerMaskTarget);

        if (hit.collider != null)
        {
            PerformAttackAction(direction);
        }
        else
        {
            CallMoveEvent(direction);
        }
    }

    private void PerformAttackAction(Vector2 direction)
    {
        CallLookEvent(direction);
        CallMoveEvent(Vector2.zero);
    }
}
