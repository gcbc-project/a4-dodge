using UnityEngine;

public class HPItem : Item
{
    [SerializeField] private int _hp;
    private HealthSystem _healthSystem;

    protected override void Effect(Collider2D collision)
    {
        _healthSystem = collision.GetComponent<HealthSystem>();

        _healthSystem.ChangeHP(_hp);
    }
}
