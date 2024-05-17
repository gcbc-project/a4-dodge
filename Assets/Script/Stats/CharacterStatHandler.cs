using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class CharacterStatHandler : MonoBehaviour
{
    public Stat CurrentStat { get; private set; }
    [SerializeField] private Stat _baseStat;
    private List<Stat> _statModifiers = new List<Stat>();    

    private void Awake()
    {
        UpdateStat();
    }

    public void UpdateStat()
    {
        CurrentStat = _baseStat.DeepCopy();
        foreach (Stat stat in _statModifiers)
        {
            switch(stat.ChangeType)
            { 
                case StatChangeType.Add:
                    break;
                case StatChangeType.Multiple:
                    break;
                case StatChangeType.Override:
                    break;

            }
        }
    }

    public void AddStat(Stat stat)
    {
        _statModifiers.Add(stat);
    }
}