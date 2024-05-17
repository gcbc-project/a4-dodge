using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class HPItem : Item
{
    [SerializeField] private int _hp;
    private HealthSystem _healthSystem;

    public override void Effect(Collider collision)
    {
        _healthSystem = collision.GetComponent<HealthSystem>();

        _healthSystem.ChangeHP(_hp);
    }
}
