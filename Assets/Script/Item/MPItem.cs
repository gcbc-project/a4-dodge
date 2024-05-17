using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPItem : MonoBehaviour, IItem
{
    // TODO : ManaSystem 클래스 구현 후 주석 풀기
    [SerializeField] private int _mp;
    //private ManaSystem _manaSystem;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어 태그에 부딪히면
        if (collision.CompareTag("Player"))
        {
            // 플레이어 ManaSystem 가져오기
            //_manaSystem = collision.GetComponent<ManaSystem>();

            // 아이템 효과 적용
            //_manaSystem.ChangeMP(_mp);

            // 아이템 파괴
            Destroy(gameObject);
        }
    }
}
