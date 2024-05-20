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

        CreateProjectile(rangeAttackSO);
    }

    public void CreateProjectile(RangeAttackSO attackData)
    {
        GameObject obj = GameManager.Instance.ObjectPool.SpawnFromPool("EnergyBall");
        obj.transform.position = _projectileSpawnPos.position;
        //ProjectileController attackController = obj.GetComponent<ProjectileController>();
        //attackController.Init(, attackData);
    }
}
