using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPItem : MonoBehaviour, IItem
{
    [SerializeField] private int Mp;
    private ManaSystem _manaSystem;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어 태그에 부딪히면
        if (collision.CompareTag("Player"))
        {
            // 플레이어 ManaSystem 가져오기
            _manaSystem = collision.GetComponent<ManaSystem>();
            // 아이템 효과 적용
            _manaSystem.ChangeMP(Mp);
            // 아이템 파괴
            Destroy(gameObject);
        }
    }
}
