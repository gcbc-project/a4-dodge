using System;
using UnityEngine;

public enum StatChangeType
{
    Add,
    Multiple,
    Override
}

[Serializable]
public class Stat
{
    public StatChangeType ChangeType;
    [Range(1, 100)] public int MaxHP;
    [Range(1, 100)] public int MaxMP;
    [Range(1f, 20f)] public float Speed;
    [Range(1f, 5f)] public float DashCoolTime;
    public AttackSO AttackData;

    public virtual Stat DeepCopy()
    {
        Stat newStat = (Stat)Activator.CreateInstance(GetType());

        newStat.ChangeType = this.ChangeType;
        newStat.MaxHP = this.MaxHP;
        newStat.MaxMP = this.MaxMP;
        newStat.Speed = this.Speed;
        newStat.DashCoolTime = this.DashCoolTime;

        if (this.AttackData != null)
        {
            newStat.AttackData = this.AttackData.DeepCopy();
        }

        return newStat;
    }

    public void Add(Stat stat)
    {
        this.MaxHP += stat.MaxHP;
        this.MaxMP += stat.MaxMP;
        this.Speed += stat.Speed;
        this.DashCoolTime += stat.DashCoolTime;
        if (stat.AttackData != null)
        {
            this.AttackData.Add(stat.AttackData);
        }
    }

    public void Multiple(Stat stat)
    {
        this.MaxHP *= stat.MaxHP;
        this.MaxMP *= stat.MaxMP;
        this.Speed *= stat.Speed;
        this.DashCoolTime *= stat.DashCoolTime;
        if (stat.AttackData != null)
        {
            this.AttackData.Multiple(stat.AttackData);
        }
    }

    public void Override(Stat stat)
    {
        this.MaxHP = stat.MaxHP;
        this.MaxMP = stat.MaxMP;
        this.Speed = stat.Speed;
        this.DashCoolTime = stat.DashCoolTime;
        if (stat.AttackData != null)
        {
            this.AttackData.Override(stat.AttackData);
        }
    }
}