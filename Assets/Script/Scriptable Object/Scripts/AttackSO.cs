using System;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Scriptable Object/Attack/Default", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Default Attack Info")]
    public float ATK;
    public float CoolTime;
    public LayerMask Target;

    public virtual AttackSO DeepCopy()
    {
        AttackSO newAttackSO = (AttackSO)Activator.CreateInstance(GetType());

        newAttackSO.ATK = this.ATK;
        newAttackSO.CoolTime = this.CoolTime;
        newAttackSO.Target = this.Target;
        return newAttackSO;
    }

    public virtual void Add(AttackSO attackData)
    {
        this.ATK += attackData.ATK;
        this.CoolTime += attackData.CoolTime;
    }

    public virtual void Multiple(AttackSO attackData)
    {
        this.ATK *= attackData.ATK;
        this.CoolTime *= attackData.CoolTime;
    }

    public virtual void Override(AttackSO attackData)
    {
        this.ATK = attackData.ATK;
        this.CoolTime = attackData.CoolTime;
    }
}
