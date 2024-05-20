using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask _levelCollisionLayer;
    private RangeAttackSO _attackData;
    private Vector2 _direction;
    private bool _isReady;
    private Rigidbody2D _rgbd;

    private void Awake()
    {
        _rgbd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _rgbd.velocity = _direction * _attackData.ProjectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(_levelCollisionLayer.value, collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - _direction * 2f;
            DestroyProjectile();
        }
        else if (IsLayerMatched(_attackData.Target.value, collision.gameObject.layer))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                bool isAttackApplied = healthSystem.ChangeHP(-_attackData.ATK);
            }
            DestroyProjectile();
        }
    }

    public void Init(Vector2 dirction, RangeAttackSO attackData)
    {
        this._attackData = attackData;
        this._direction = dirction;

        UpdateProjectileSprite();

        transform.right = this._direction;
        _isReady = true;
    }

    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    private void UpdateProjectileSprite()
    {
        transform.localScale = Vector3.one * _attackData.ProjectileSize;
    }
}
