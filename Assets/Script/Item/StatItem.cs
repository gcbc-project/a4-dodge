using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : Item
{
    [SerializeField] private Stat _effectStat;
    private CharacterStatHandler _characterStatHandler;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            _characterStatHandler = collision.GetComponent<CharacterStatHandler>();

            _characterStatHandler.AddStat(_effectStat);
            _characterStatHandler.UpdateStat();

            Destroy(gameObject);
        }
    }
}
