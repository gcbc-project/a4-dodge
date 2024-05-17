using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int _playerLayer = LayerMask.GetMask("Player");

    protected abstract void OnTriggerEnter2D(Collider2D collision);
}
