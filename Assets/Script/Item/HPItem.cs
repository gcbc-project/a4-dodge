using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : Item
{
    [SerializeField] private LayerMask _collisionLayer;
    [SerializeField] private int _hp;
    private HealthSystem _healthSystem;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            _healthSystem = collision.GetComponent<HealthSystem>();

            _healthSystem.ChangeHP(_hp);

            Destroy(gameObject);
        }
    }
}
