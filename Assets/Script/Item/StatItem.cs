using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour, IItem
{
    // TODO : _statModifiers, CharacterStatHandler 클래스 구현 후 주석 풀기
    //[SerializeField] private Stat _effectStat;
    //private CharacterStatHandler _characterStatHandler;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어 태그에 부딪히면
        if (collision.CompareTag("Player"))
        {
            // 플레이어 CharacterStatHandler 가져오기
            //_characterStatHandler = collision.GetComponent<CharacterStatHandler>();

            // 아이템 효과 적용
            //_characterStatHandler._statModifiers.Add(_effectStat);
            //_characterStatHandler.UpdateStat();

            // 아이템 파괴
            Destroy(gameObject);
        }
    }
}
