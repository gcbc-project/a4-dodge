using UnityEngine;

[CreateAssetMenu(fileName = "RangeAttackSO", menuName = "Scriptable Object/Attack/Range", order = 2)]
public class RangeAttackSO : AttackSO
{
    [Header("Range Attack Info")]
    public string ProjectileNameTag;
    public int ProjectileNum;
    public float ProjectileSize;
    public float ProjectileSpeed;
    public float ProjectileAngle;

    public override AttackSO DeepCopy()
    {
        RangeAttackSO newAttackSO = (RangeAttackSO)base.DeepCopy();

        newAttackSO.ProjectileNameTag = this.ProjectileNameTag;
        newAttackSO.ProjectileNum = this.ProjectileNum;
        newAttackSO.ProjectileSize = this.ProjectileSize;
        newAttackSO.ProjectileSpeed = this.ProjectileSpeed;
        newAttackSO.ProjectileAngle = this.ProjectileAngle;
        return newAttackSO;
    }

    public override void Add(AttackSO attackData)
    {
        base.Add(attackData);
        RangeAttackSO newAttackSO = attackData as RangeAttackSO;
        if (newAttackSO != null)
        {
            this.ProjectileNum += newAttackSO.ProjectileNum;
            this.ProjectileSize += newAttackSO.ProjectileSize;
            this.ProjectileSpeed += newAttackSO.ProjectileSpeed;
            this.ProjectileAngle += newAttackSO.ProjectileAngle;
        }
    }

    public override void Multiple(AttackSO attackData)
    {
        base.Multiple(attackData);
        RangeAttackSO newAttackSO = attackData as RangeAttackSO;
        if (newAttackSO != null)
        {
            this.ProjectileNum *= newAttackSO.ProjectileNum;
            this.ProjectileSize *= newAttackSO.ProjectileSize;
            this.ProjectileSpeed *= newAttackSO.ProjectileSpeed;
            this.ProjectileAngle *= newAttackSO.ProjectileAngle;
        }
    }

    public override void Override(AttackSO attackData)
    {
        base.Override(attackData);
        RangeAttackSO newAttackSO = attackData as RangeAttackSO;
        if (newAttackSO != null)
        {
            this.ProjectileNum = newAttackSO.ProjectileNum;
            this.ProjectileSize = newAttackSO.ProjectileSize;
            this.ProjectileSpeed = newAttackSO.ProjectileSpeed;
            this.ProjectileAngle = newAttackSO.ProjectileAngle;
        }
    }
}
