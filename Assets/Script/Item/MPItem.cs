using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPItem : Item
{
    [SerializeField] private int _mp;
    private ManaSystem _manaSystem;

    public override void Effect(Collider collision)
    {
        _manaSystem = collision.GetComponent<ManaSystem>();

        _manaSystem.ChangeMP(_mp);
    }
}
