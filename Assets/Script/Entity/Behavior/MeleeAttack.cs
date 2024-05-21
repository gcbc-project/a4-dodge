using System;
using UnityEngine;

public class MeleeAttack : Attack
{
    private AttackSO _tempAttackData;

    protected override void ExecuteAttack(AttackSO attackData)
    {
        MeleeAttackSO meleeAttackSO = attackData as MeleeAttackSO;
        Vector2 origin = transform.position;
        float halfAngle = meleeAttackSO.Angle * 0.5f;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(origin, meleeAttackSO.Reach, meleeAttackSO.Target);

        foreach (Collider2D target in hitEnemies)
        {
            Vector2 targetOrigin = target.transform.position;
            Vector2 directionToTarget = (targetOrigin - origin).normalized;
            float angleToTarget = Vector2.Angle(_direction, directionToTarget);

            if (angleToTarget < halfAngle)
            {
                Hit();
                continue;
            }

            RaycastHit2D hitMax = Physics2D.Raycast(origin, Quaternion.Euler(0, 0, halfAngle) * _direction, meleeAttackSO.Reach, meleeAttackSO.Target);
            RaycastHit2D hitMin = Physics2D.Raycast(origin, Quaternion.Euler(0, 0, -halfAngle) * _direction, meleeAttackSO.Reach, meleeAttackSO.Target);

            if(hitMax.collider != null || hitMin.collider != null)
            {
                Hit();
            }
        }

        _tempAttackData= attackData;
    }

    private void Hit()
    {
        Debug.Log("123");
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
