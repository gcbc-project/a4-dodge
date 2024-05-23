using UnityEngine;

[CreateAssetMenu(fileName = "MeleeAttackSO", menuName = "Scriptable Object/Attack/Melee", order = 1)]
public class MeleeAttackSO : AttackSO
{
    [Header("Melee Attack Info")]
    public float Reach;
    public float Angle;

    public override AttackSO DeepCopy()
    {
        MeleeAttackSO newAttackSO = (MeleeAttackSO)base.DeepCopy();

        newAttackSO.Reach = this.Reach;
        newAttackSO.Angle = this.Angle;
        return newAttackSO;
    }

    public override void Add(AttackSO attackData)
    {
        base.Add(attackData);
        MeleeAttackSO newAttackSO = attackData as MeleeAttackSO;

        this.Reach += newAttackSO.Reach;
        this.Angle += newAttackSO.Angle;
    }

    public override void Multiple(AttackSO attackData)
    {
        base.Multiple(attackData);
        MeleeAttackSO newAttackSO = attackData as MeleeAttackSO;

        this.Reach *= newAttackSO.Reach;
        this.Angle *= newAttackSO.Angle;
    }

    public override void Override(AttackSO attackData)
    {
        base.Override(attackData);
        MeleeAttackSO newAttackSO = attackData as MeleeAttackSO;

        this.Reach = newAttackSO.Reach;
        this.Angle = newAttackSO.Angle;
    }
}
