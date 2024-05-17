using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPItem : Item
{
    [SerializeField] private int _mp;
    private ManaSystem _manaSystem;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            _manaSystem = collision.GetComponent<ManaSystem>();

            _manaSystem.ChangeMP(_mp);

            Destroy(gameObject);
        }
    }
}
