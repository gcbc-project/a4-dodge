using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

public class RangeAttack : Attack
{
    [SerializeField] private Transform _projectileSpawnPos;

    protected override void ExecuteAttack(AttackSO attackData)
    {
        RangeAttackSO rangeAttackSO = attackData as RangeAttackSO;
        if (rangeAttackSO == null) return;

        //CreateProjectile(rangeAttackSO);

        float projectilesAngleSpace = rangeAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = rangeAttackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangeAttackSO.multipleProjectilesAngle;
        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = Random.Range(-rangeAttackSO.spread, rangeAttackSO.spread);
            angle += randomSpread;
            CreateProjectile(rangeAttackSO, angle);
        }
    }

    public void CreateProjectile(RangeAttackSO attackData)
    {
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool("EnergyBall");
        obj.transform.position = _projectileSpawnPos.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.Init(_direction, attackData);
    }
}
