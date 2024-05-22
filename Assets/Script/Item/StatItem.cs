using UnityEngine;

public class StatItem : Item
{
    [SerializeField] private Stat _effectStat;
    private CharacterStatHandler _characterStatHandler;

    protected override void Effect(Collider2D collision)
    {
        _characterStatHandler = collision.GetComponent<CharacterStatHandler>();

        _characterStatHandler.AddStat(_effectStat);
        _characterStatHandler.UpdateStat();
    }
}
