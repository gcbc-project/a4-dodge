using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int _playerLayer = LayerMask.GetMask("Player");

    public abstract void Effect(Collider collision);

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            Effect(collision);
            Destroy(gameObject);
        }
    }
}
