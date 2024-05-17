using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatItem : MonoBehaviour, IItem
{
    [SerializeField]private Stat EffectStat;
    private CharacterStatHandler _characterStatHandler;

    void IItem.OnTriggerEnter2D(Collider2D collision)
    {
        // �÷��̾� �±׿� �ε�����
        if (collision.CompareTag("Player"))
        {
            // �÷��̾� Stat ��������
            _characterStatHandler = collision.GetComponent<CharacterStatHandler>();
            // ������ ȿ�� ����
            _characterStatHandler.Stats.Add(EffectStat);
            _characterStatHandler.UpdateStat();
            // ������ �ı�
            Destroy(gameObject);
        }
    }
}
