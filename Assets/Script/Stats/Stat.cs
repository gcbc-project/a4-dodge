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
    [Range(0, 100)] public int MaxHP;
    [Range(0, 100)] public int MaxMP;
    [Range(0f, 20f)] public float Speed;
    [Range(0f, 10f)] public float DashSpeed;
    [Range(0f, 5f)] public float DashCoolTime;
    [Range(0f, 5f)] public float DashHoldTime;
    public AttackSO AttackData;

    public virtual Stat DeepCopy()
    {
        Stat newStat = (Stat)Activator.CreateInstance(GetType());

        newStat.ChangeType = this.ChangeType;
        newStat.MaxHP = this.MaxHP;
        newStat.MaxMP = this.MaxMP;
        newStat.Speed = this.Speed;
        newStat.DashSpeed = this.DashSpeed;
        newStat.DashCoolTime = this.DashCoolTime;
        newStat.DashHoldTime = this.DashHoldTime;

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
        this.DashSpeed += stat.DashSpeed;
        this.DashCoolTime += stat.DashCoolTime;
        this.DashHoldTime += stat.DashHoldTime;
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
        this.DashSpeed *= stat.DashSpeed;
        this.DashCoolTime *= stat.DashCoolTime;
        this.DashHoldTime *= stat.DashHoldTime;
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
        this.DashSpeed = stat.DashSpeed;
        this.DashCoolTime = stat.DashCoolTime;
        this.DashHoldTime = stat.DashHoldTime;
        if (stat.AttackData != null)
        {
            this.AttackData.Override(stat.AttackData);
        }
    }
}