using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int _playerLayer;

    protected abstract void Effect(Collider2D collision);
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            Effect(collision);
            Destroy(gameObject);
        }
    }
}
