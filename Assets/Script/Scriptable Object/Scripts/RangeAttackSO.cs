using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttackSO", menuName = "Scriptable Object/Attack/Range", order = 2)]
public class RangeAttackSO : AttackSO
{
    [Header("Range Attack Info")]
    public int ProjectileNum;
    public float ProjectileSize;
    public float ProjectileSpeed;

    public override AttackSO DeepCopy()
    {
        RangeAttackSO newAttackSO = (RangeAttackSO)base.DeepCopy();

        newAttackSO.ProjectileNum = this.ProjectileNum;
        newAttackSO.ProjectileSize = this.ProjectileSize;
        newAttackSO.ProjectileSpeed = this.ProjectileSpeed;
        return newAttackSO;
    }

    public override void Add(AttackSO attackData)
    {
        base.Add(attackData);
        this.ATK += attackData.ATK;
        this.CoolTime += attackData.CoolTime;
    }

    public override void Multiple(AttackSO attackData)
    {
        base.Multiple(attackData);
        this.ATK *= attackData.ATK;
        this.CoolTime *= attackData.CoolTime;
    }

    public override void Override(AttackSO attackData)
    {
        base.Override(attackData);
        this.ATK = attackData.ATK;
        this.CoolTime = attackData.CoolTime;
    }
}
