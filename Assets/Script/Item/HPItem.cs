using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour, IItem
{
    [SerializeField] private int Hp;
    private HealthSystem _healthSystem;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어 태그에 부딪히면
        if (collision.CompareTag("Player"))
        {
            // 플레이어 HealthSystem 가져오기
            _healthSystem = collision.GetComponent<HealthSystem>();
            // 아이템 효과 적용
            _healthSystem.ChangeHP(Hp);
            // 아이템 파괴
            Destroy(gameObject);
        }
    }
}
