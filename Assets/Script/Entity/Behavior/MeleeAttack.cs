using System;
using UnityEngine;

public class MeleeAttack : Attack
{
    private AttackSO _tempAttackData;

    protected override void ExecuteAttack(AttackSO attackData)
    {
        MeleeAttackSO meleeAttackSO = attackData as MeleeAttackSO;

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_direction, meleeAttackSO.Angle, meleeAttackSO.Target);

        foreach (Collider2D target in hitEnemies)
        {
            Vector2 directionToTarget = ((Vector2)target.ClosestPoint(_direction) - _direction).normalized;
            float angleToTarget = Vector2.Angle(_direction, directionToTarget);

            if (angleToTarget < meleeAttackSO.Angle / 2)
            {
                Debug.Log("123");
            }
        }

        //Collider2D[] hitEnemies = Physics2D.OverlapAreaAll(
        //    CalculateSectorPoint(attackData,_direction, -1),
        //    CalculateSectorPoint(attackData,_direction),
        //    attackData.Target
        //);
        _tempAttackData= attackData;
    }

    private Vector2 CalculateSectorPoint(AttackSO attackData, Vector2 center, int direction = 1)
    {
        MeleeAttackSO meleeAttackSO = attackData as MeleeAttackSO;
        float halfAngle = meleeAttackSO.Angle / 2f;
        Vector2 direc = Quaternion.Euler(0, 0, direction * halfAngle) * center.normalized;

        return direc * meleeAttackSO.Reach;
    }

    public void OnDrawGizmosSelected()
    {
        try
        {
            MeleeAttackSO meleeAttackSO = _tempAttackData as MeleeAttackSO;
            Vector2 playerPosition = _controller.transform.position;
            Vector2 startPoint = CalculateSectorPoint(_tempAttackData, _direction, -1);
            Vector2 endPoint = CalculateSectorPoint(_tempAttackData, _direction);

            Gizmos.color = Color.red;

            Gizmos.DrawLine(playerPosition, playerPosition + startPoint);
            Gizmos.DrawLine(playerPosition, playerPosition + endPoint);
        }
        catch (Exception) { }
    }
}
