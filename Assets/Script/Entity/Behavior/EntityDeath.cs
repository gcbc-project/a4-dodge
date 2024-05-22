using UnityEngine;

public class EntityDeath : MonoBehaviour
{
    private HealthSystem _healthSystem;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _healthSystem.OnDeathEvent += OnDeath;
    }

    private void OnDeath()
    {
        Destroy(gameObject);

        // Death 애니메이션을 넣을 지, 아래 코드를 사용할 지 선택
        
        //_rigidbody.velocity = Vector2.zero;

        //foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        //{
        //    Color color = renderer.color;
        //    color.a = 0.3f;
        //    renderer.color = color;
        //}

        //foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        //{
        //    behaviour.enabled = false;
        //}

        //Destroy(gameObject, 1f);
    }
}
