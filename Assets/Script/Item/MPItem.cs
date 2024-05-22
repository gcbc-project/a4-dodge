using UnityEngine;

public class MPItem : Item
{
    [SerializeField] private int _mp;
    private ManaSystem _manaSystem;

    protected override void Effect(Collider2D collision)
    {
        _manaSystem = collision.GetComponent<ManaSystem>();

        _manaSystem.ChangeMP(_mp);
    }
}
